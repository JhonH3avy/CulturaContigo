using AutoMapper;
using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Manager.Activities.Administration.Contract;

namespace CulturaContigo.Api.Manager.Activities.Administration;

internal class ActivitiesManager : IActivitiesManager
{
    private IMapper _mapper;
    private IActivitiesAccess _activitiesAccess;

    public ActivitiesManager(IMapper mapper, IActivitiesAccess activitiesAccess)
    {
        _mapper = mapper;
        _activitiesAccess = activitiesAccess;
    }

    public async Task<Contract.Activity> CreateActivity(Contract.ActivityCreateRequest activityCreateRequest)
    {
        var accessActivityCreateRequest = _mapper.Map<Access.Activities.Contract.ActivityCreateRequest>(activityCreateRequest);
        var accessActivity = await _activitiesAccess.CreateActivity(accessActivityCreateRequest);
        var result = _mapper.Map<Contract.Activity>(accessActivity);
        return result;
    }
}
