using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][Range(1, 20)] int GenreId,
    [Required][Range(1, 100)] decimal Price,
    [Required] DateOnly ReleaseDate
);
