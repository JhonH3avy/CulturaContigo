namespace CulturaContigo.Api.Access.Ticket.Contract;

public interface ITicketAccess
{
    Task<Ticket> CreateTicket(TicketCreateRequest ticketCreateRequest);
}