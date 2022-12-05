namespace CulturaContigo.Api.Access.Activities.Contract;
public record GetActivitiesInDateRangeRequest
{
    public GetActivitiesInDateRangeRequest()
    {
        PaginationOptions = new PaginationOptions();
    }

    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public PaginationOptions PaginationOptions { get; set; }
}
