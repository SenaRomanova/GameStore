using System;

namespace GameStore.api.Entities;

public class GenreEntity
{

    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty; //need to define a default value
                                                              //could do a nullable string? but we wouldnt't want that in the db
                                                              //could also do setting to string.Empty in the constructor
}
