namespace CulturaContigo.Api.Access.Activities.Contract;

public record PaginationOptions
{
    public int Page { get; set; }
    public int Size { get; set; }
}
