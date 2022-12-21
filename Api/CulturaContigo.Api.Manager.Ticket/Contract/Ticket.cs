namespace CulturaContigo.Api.Manager.Ticket.Contract;

public record Ticket
{
    public int Id { get; init; }
    public int ActivityId { get; init; }
    required public string TypeOfId { get; init; }
    required public string PersonalId { get; init; }
    public int NumberOfTickets { get; init; }
}
