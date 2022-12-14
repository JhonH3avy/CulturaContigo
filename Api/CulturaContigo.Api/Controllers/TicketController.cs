using AutoMapper;
using CulturaContigo.Api.Manager.Ticket.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CulturaContigo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private IMapper _mapper;
    private ITicketManager _ticketManager;


    public TicketController(IMapper mapper, ITicketManager ticketManager)
    {
        _mapper = mapper;
        _ticketManager = ticketManager;
    }

    [HttpPost]
    public async Task<Models.Ticket> Post([FromBody] Models.TicketCreateRequest ticketCreateRequest)
    {
        var managerTicketCreateRequest = _mapper.Map<Manager.Ticket.Contract.TicketCreateRequest>(ticketCreateRequest);
        var managerTicket = await _ticketManager.CreateTicket(managerTicketCreateRequest);
        var result = _mapper.Map<Models.Ticket>(managerTicket);
        return result;
    }
}
