namespace CulturaContigo.Api.Access.Ticket.Contract;

public record TicketCreateRequest
{
    public int ActivityId { get; set; }
    required public string TypeOfId { get; set; }
    required public string PersonalId { get; set; }
    public int NumberOfTickets { get; set; }
}
