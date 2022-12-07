using System.ComponentModel.DataAnnotations;

namespace CulturaContigo.Api.Models;

public record TicketCreateRequest
{
    [Required]
    public int ActivityId { get; set; }
    [Required]
    public string? TypeOfId { get; set; }
    [Required]
    public string? PersonalId { get; set; }
    [Required]
    public int NumberOfTickets { get; set; }
}
