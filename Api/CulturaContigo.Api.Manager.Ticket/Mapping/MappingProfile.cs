using AutoMapper;

namespace CulturaContigo.Api.Manager.Ticket.Mapping;

internal class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Contract.TicketCreateRequest, Access.Ticket.Contract.TicketCreateRequest>();

		CreateMap<Access.Ticket.Contract.Ticket, Contract.Ticket>();
	}
}
