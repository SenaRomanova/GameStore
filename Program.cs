using GameStore.api.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
const string GetGameEndpointName = "GetGame";


List<GameDTO> games = [
    new GameDTO(1, "The Legend of Zelda: Breath of the Wild", "Action-adventure", 59.99m, new DateOnly(2017, 3, 3)), //m specifies that this is a decimal
    new GameDTO(2, "Super Mario Odyssey", "Platform", 49.99m, new DateOnly(2017, 10, 27)),
    new GameDTO(3, "Red Dead Redemption 2", "Action-adventure", 39.99m, new DateOnly(2018, 10, 26)),
    new GameDTO(4, "The Witcher 3: Wild Hunt", "Action RPG", 29.99m, new DateOnly(2015, 5, 19)),
];

//the following is a response to GET /games
app.MapGet("games", () => games); //name of endpoint same as plural of the resource which is games, lambda that returns the list of games

//request to retieve one game
//GET /games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))//"game WHERE game.Id is equal to id"
.WithName(GetGameEndpointName); //name the endpoint so that we can refer to it later
//naming the endpoint is useful when we want to refer to it later, e.g., in CreatedAtRoute

//creation of a resource
//new endpoit is POST /games
app.MapPost("games", (CreateGameDTO newGame) =>
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



app.Run();
