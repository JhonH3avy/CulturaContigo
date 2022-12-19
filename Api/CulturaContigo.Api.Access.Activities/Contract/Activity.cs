namespace CulturaContigo.Api.Access.Activities.Contract;

public record Activity
{
    public Activity()
    {
        Name = string.Empty;
        Details = string.Empty;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public DateTime? ScheduledDateTime { get; set; }
    public string? Place { get; set; }
    public decimal? TicketPrice { get; set; }
    public int? Capacity { get; set; }
    public int? Available { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsDeleted { get; set; }
}
