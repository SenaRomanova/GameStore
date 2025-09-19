namespace GameStore.api.DTOs;

public record class CreateGameDTO
(
    //int Id -- the id is provided by the server/api itself!
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
