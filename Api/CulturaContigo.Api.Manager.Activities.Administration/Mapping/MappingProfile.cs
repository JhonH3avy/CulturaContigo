using AutoMapper;

namespace CulturaContigo.Api.Manager.Activities.Administration.Mapping;

internal class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Contract.ActivityCreateRequest, Access.Activities.Contract.ActivityCreateRequest>();

		CreateMap<Access.Activities.Contract.Activity, Contract.Activity>();
	}
}