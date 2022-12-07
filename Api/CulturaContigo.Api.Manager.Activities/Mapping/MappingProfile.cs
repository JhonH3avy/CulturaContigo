using AutoMapper;
using CulturaContigo.Api.Manager.Activities.Contract;

namespace CulturaContigo.Api.Manager.Activities.Mapping;

internal class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<ActivityCreateRequest, Access.Activities.Contract.ActivityCreateRequest>();

		CreateMap<Access.Activities.Contract.Activity, Activity>();

		CreateMap<PaginationOptions, Access.Activities.Contract.PaginationOptions>();

		CreateMap<GetActivitiesInDateRangeRequest, Access.Activities.Contract.GetActivitiesInDateRangeRequest>();
	}
}