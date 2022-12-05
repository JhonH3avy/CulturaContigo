namespace CulturaContigo.Api.Access.Activities.Contract;

public class ActivityCreateRequest
{
    public ActivityCreateRequest()
    {
        Name = string.Empty;
        Details = string.Empty;
    }

    public string Name { get; set; }
    public string Details { get; set; }
    public DateTime? ScheduledDateTime { get; set; }
    public string? Place { get; set; }
    public decimal? TicketPrice { get; set; }
    public int? Capacity { get; set; }
    public string? ImageUrl { get; set; }
}
