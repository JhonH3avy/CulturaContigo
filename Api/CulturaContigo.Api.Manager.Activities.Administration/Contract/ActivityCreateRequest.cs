namespace CulturaContigo.Api.Manager.Activities.Administration.Contract;

public record ActivityCreateRequest
{
    required public string Name { get; init; }
    required public string Details { get; init; }
    public DateTime? ScheduledDateTime { get; init; }
    public string? Place { get; init; }
    public decimal? TicketPrice { get; init; }
    public int? Capacity { get; init; }
    public string? ImageUrl { get; init; }
}
