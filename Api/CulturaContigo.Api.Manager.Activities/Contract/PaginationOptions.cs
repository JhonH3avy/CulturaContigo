namespace CulturaContigo.Api.Manager.Activities.Contract;

public record PaginationOptions
{
    public int Page { get; set; }
    public int Size { get; set; }
}
