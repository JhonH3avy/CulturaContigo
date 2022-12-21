using System.ComponentModel.DataAnnotations;

namespace CulturaContigo.Api.Models;

public record TicketCreateRequest
{
    [Required]
    public int ActivityId { get; init; }
    [Required]
    public string? TypeOfId { get; init; }
    [Required]
    public string? PersonalId { get; init; }
    [Required]
    public int NumberOfTickets { get; init; }
}
