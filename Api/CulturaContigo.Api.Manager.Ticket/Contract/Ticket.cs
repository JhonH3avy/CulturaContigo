namespace CulturaContigo.Api.Manager.Ticket.Contract;

public record Ticket
{
    public int Id { get; set; }
    public int ActivityId { get; set; }
    required public string TypeOfId { get; set; }
    required public string PersonalId { get; set; }
    public int NumberOfTickets { get; set; }
}
