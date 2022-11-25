namespace CulturaContigo.Api.Models;

public class Ticket
{
    public Ticket()
    {
        TypeOfId = string.Empty;
        PersonalId = string.Empty;
    }

    public int Id { get; set; }
    public int ActivityId { get; set; }
    public string TypeOfId { get; set; }
    public string PersonalId { get; set; }
    public int NumberOfTickets { get; set; }
}
