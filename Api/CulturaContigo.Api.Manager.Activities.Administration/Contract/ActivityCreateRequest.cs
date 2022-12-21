namespace CulturaContigo.Api.Manager.Activities.Administration.Contract;

public record ActivityCreateRequest
{
    required public string Name { get; set; }
    required public string Details { get; set; }
    public DateTime? ScheduledDateTime { get; set; }
    public string? Place { get; set; }
    public decimal? TicketPrice { get; set; }
    public int? Capacity { get; set; }
    public string? ImageUrl { get; set; }
}
