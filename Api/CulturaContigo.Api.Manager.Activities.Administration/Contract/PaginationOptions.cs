namespace CulturaContigo.Api.Manager.Activities.Administration.Contract;

public record PaginationOptions
{
    public int Page { get; set; }
    public int Size { get; set; }
}
