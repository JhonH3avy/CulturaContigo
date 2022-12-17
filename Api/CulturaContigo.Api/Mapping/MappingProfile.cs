using AutoMapper;
using CulturaContigo.Api.Models.Administration;

namespace CulturaContigo.Api.Mapping;

internal class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<ActivityCreateRequest, Manager.Activities.Contract.ActivityCreateRequest>();

		CreateMap<Manager.Activities.Contract.Activity, Models.Activity>();

        CreateMap<ActivityCreateRequest, Manager.Activities.Administration.Contract.ActivityCreateRequest>();

        CreateMap<Manager.Activities.Administration.Contract.Activity, Models.Activity>();

        CreateMap<Models.PaginationOptions, Manager.Activities.Contract.PaginationOptions>();

		CreateMap<Models.TicketCreateRequest, Manager.Ticket.Contract.TicketCreateRequest>();

		CreateMap<Manager.Ticket.Contract.Ticket, Models.Ticket>();
	}
}