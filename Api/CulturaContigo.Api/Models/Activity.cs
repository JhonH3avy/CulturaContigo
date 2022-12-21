namespace CulturaContigo.Api.Models;

public record Activity
{
    public int Id { get; set; }
    required public string Name { get; set; }
    required public string Details { get; set; }
    public DateTime? ScheduledDateTime { get; set; }
    public string? Place { get; set; }
    public decimal? TicketPrice { get; set; }
    public int? Capacity { get; set; }
    public int? Available { get; set; }
    public string? ImageUrl { get; set; }
}
