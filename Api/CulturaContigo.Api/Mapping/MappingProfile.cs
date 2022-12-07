using AutoMapper;

namespace CulturaContigo.Api.Mapping;

internal class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Models.ActivityCreateRequest, Manager.Activities.Contract.ActivityCreateRequest>();

		CreateMap<Manager.Activities.Contract.Activity, Models.Activity>();

		CreateMap<Models.PaginationOptions, Manager.Activities.Contract.PaginationOptions>();
	}
}