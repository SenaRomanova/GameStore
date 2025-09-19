namespace GameStore.api.DTOs;

public record class GameDTO(int Id, string Name, string Genre, decimal Price, DateOnly ReleaseDate); //DateTime if care about time

