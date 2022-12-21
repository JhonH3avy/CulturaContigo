namespace CulturaContigo.Api.Manager.Activities.Contract;
public record GetActivitiesInDateRangeRequest
{
    public DateTime StartDateTime { get; init; }
    public DateTime EndDateTime { get; init; }
    required public PaginationOptions PaginationOptions { get; init; }
}
