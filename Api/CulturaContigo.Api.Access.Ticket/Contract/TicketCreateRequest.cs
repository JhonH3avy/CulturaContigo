using System.ComponentModel.DataAnnotations;

namespace CulturaContigo.Api.Access.Ticket.Contract;

public record TicketCreateRequest
{
    public TicketCreateRequest()
    {
        TypeOfId = string.Empty;
        PersonalId = string.Empty;
    }

    public int ActivityId { get; set; }
    public string TypeOfId { get; set; }
    public string PersonalId { get; set; }
    public int NumberOfTickets { get; set; }
}
