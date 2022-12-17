using System.ComponentModel.DataAnnotations;

namespace CulturaContigo.Api.Models.Administration;

public record ActivityCreateRequest
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Details { get; set; }
    public DateTime? ScheduledDateTime { get; set; }
    public string? Place { get; set; }
    public decimal? TicketPrice { get; set; }
    public int? Capacity { get; set; }
    public string? ImageUrl { get; set; }
}
