namespace CulturaContigo.Api.Manager.Ticket.Contract;

public interface ITicketManager
{
    Task<Ticket> CreateTicket(TicketCreateRequest ticketCreateRequest);
}