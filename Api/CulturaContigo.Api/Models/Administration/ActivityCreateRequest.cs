using System.ComponentModel.DataAnnotations;

namespace CulturaContigo.Api.Models.Administration;

public record ActivityCreateRequest
{
    [Required]
    public string? Name { get; init; }
    [Required]
    public string? Details { get; init; }
    public DateTime? ScheduledDateTime { get; init; }
    public string? Place { get; init; }
    public decimal? TicketPrice { get; init; }
    public int? Capacity { get; init; }
    public string? ImageUrl { get; init; }
}
