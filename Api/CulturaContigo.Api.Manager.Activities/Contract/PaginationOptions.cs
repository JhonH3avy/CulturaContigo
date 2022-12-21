namespace CulturaContigo.Api.Manager.Activities.Contract;

public record PaginationOptions
{
    public int Page { get; init; }
    public int Size { get; init; }
}
