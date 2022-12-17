using AutoMapper;
using CulturaContigo.Api.Access.Ticket.Contract;
using CulturaContigo.Api.Manager.Ticket.Contract;

namespace CulturaContigo.Api.Manager.Ticket;

internal class TicketManager : ITicketManager
{
    private IMapper _mapper;
    private ITicketAccess _ticketAccess;

    public TicketManager(IMapper mapper, ITicketAccess ticketAccess)
    {
        _mapper = mapper;
        _ticketAccess = ticketAccess;
    }

    public async Task<Contract.Ticket> CreateTicket(Contract.TicketCreateRequest ticketCreateRequest)
    {
        var accessTicketCreateRequest = _mapper.Map<Access.Ticket.Contract.TicketCreateRequest>(ticketCreateRequest);
        var accessTicket = await _ticketAccess.CreateTicket(accessTicketCreateRequest);
        var result = _mapper.Map<Contract.Ticket>(accessTicket);
        return result;
    }
}
