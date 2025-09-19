using System.ComponentModel.DataAnnotations;

namespace GameStore.api.DTOs;

public record class UpdateGameDTO
(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Required][Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
