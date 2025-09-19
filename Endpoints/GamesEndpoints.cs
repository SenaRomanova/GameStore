using System;
using GameStore.api.DTOs;

namespace GameStore.api.Endpoints;

//a static class have extension static methods
//extend one of the classes we don't own (application) with functionality our api needs
public static class GamesEndpoints
{

    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDTO> games = [ //readonly because we only assign list once, on declaration
        new GameDTO(1, "The Legend of Zelda: Breath of the Wild", "Action-adventure", 59.99m, new DateOnly(2017, 3, 3)), //m specifies that this is a decimal
        new GameDTO(2, "Super Mario Odyssey", "Platform", 49.99m, new DateOnly(2017, 10, 27)),
        new GameDTO(3, "Red Dead Redemption 2", "Action-adventure", 39.99m, new DateOnly(2018, 10, 26)),
        new GameDTO(4, "The Witcher 3: Wild Hunt", "Action RPG", 29.99m, new DateOnly(2015, 5, 19)),
    ];

    //extension method 
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)//used to return WebApplication but then we added a var group
    {
        var group = app.MapGroup("/games")
                                .WithParameterValidation(); //grouping endpoints(links) under /games, so all further endpoints will be relative to this


        //the following is a response to GET /games
        group.MapGet("/", () => games); //name of endpoint same as plural of the resource which is games, lambda that returns the list of games

        //request to retieve one game
        //GET /games/1
        group.MapGet("/{id}", (int id) =>
        {
            GameDTO? game = games.Find(game => game.Id == id);//"game WHERE game.Id is equal to id"

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName); //naming the endpoint is useful when we want to refer to it later, e.g., in CreatedAtRoute

        //creation of a resource
        //new endpoit is POST /games
        group.MapPost("/", (CreateGameDTO newGame) =>
        {


            GameDTO game = new(
                Id: games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
                );

            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game); //returns 201 Created response with a Location header pointing to the newly created resource
        });
        //.WithParameterValidation(); //installed provided by nuget package - MinimalApis.Extensions, to enforce the data annotations in CreateGameDTO.

        //PUT endpoint
        group.MapPut("/{id}", (int id, UpdateGameDTO updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);//returns -1 if game not found

            if (index == -1)
            {
                return Results.NotFound(); //can create a brand new resource instead. 
            }

            games[index] = new GameDTO(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );
            return Results.NoContent();
        }
        );

        //DELETE endpoint
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        }
        );
        return group;
    }

}
