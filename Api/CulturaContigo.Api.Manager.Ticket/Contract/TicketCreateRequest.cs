namespace CulturaContigo.Api.Manager.Ticket.Contract;

public record TicketCreateRequest
{
    public int ActivityId { get; init; }
    required public string TypeOfId { get; init; }
    required public string PersonalId { get; init; }
    public int NumberOfTickets { get; init; }
}
