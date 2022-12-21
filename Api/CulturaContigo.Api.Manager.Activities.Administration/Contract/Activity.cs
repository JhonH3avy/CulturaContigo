namespace CulturaContigo.Api.Manager.Activities.Administration.Contract;

public record Activity
{
    public int Id { get; init; }
    required public string Name { get; init; }
    required public string Details { get; init; }
    public DateTime? ScheduledDateTime { get; init; }
    public string? Place { get; init; }
    public decimal? TicketPrice { get; init; }
    public int? Capacity { get; init; }
    public int? Available { get; init; }
    public string? ImageUrl { get; init; }
}
