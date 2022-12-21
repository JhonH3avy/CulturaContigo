namespace CulturaContigo.Api.Access.Activities.Contract;

public record PaginationOptions
{
    public int Page { get; init; }
    public int Size { get; init; }
}
