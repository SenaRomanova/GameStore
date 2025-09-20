using System.ComponentModel.DataAnnotations;

namespace GameStore.api.DTOs;

public record class CreateGameDTO
(
    //int Id -- the id is provided by the server/api itself!

    //to enforce the data annotations, use a nuget package: MinimalApis.Extensions
    [Required][StringLength(50)] string Name,
    [Required] int GenreId,
    [Required][Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
