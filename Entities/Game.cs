using System;

namespace GameStore.api.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }

    //relational model to assoc game with genre:
    public int GenreId { get; set; } //connects to Genre.Id
    public Genre? Genre { get; set; } //navigation property to access genre details. genre can be nullable

    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
