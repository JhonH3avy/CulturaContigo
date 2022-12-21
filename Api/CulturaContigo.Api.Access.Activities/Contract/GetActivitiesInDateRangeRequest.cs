namespace CulturaContigo.Api.Access.Activities.Contract;
public record GetActivitiesInDateRangeRequest
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    required public PaginationOptions PaginationOptions { get; set; }
}
