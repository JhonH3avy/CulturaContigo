namespace CulturaContigo.Api.Models;

public record PaginationOptions
{
    public int Page { get; init; }
    public int Size { get; init; }
}
