using AutoMapper;
using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Manager.Activities.Contract;

namespace CulturaContigo.Api.Manager.Activities;

internal class ActivitiesManager : IActivitiesManager
{
    private IMapper _mapper;
    private readonly IActivitiesAccess _activitiesAccess;

    public ActivitiesManager(IMapper mapper, IActivitiesAccess activitiesAccess)
    {
        _mapper = mapper;
        _activitiesAccess = activitiesAccess;
    }

    public async Task<Contract.Activity> CreateActivity(Contract.ActivityCreateRequest activityCreateRequest)
    {
        var accessActivityCreateRequest = _mapper.Map<Access.Activities.Contract.ActivityCreateRequest>(activityCreateRequest);
        var accessActivity = await _activitiesAccess.CreateActivity(accessActivityCreateRequest);
        var result = _mapper.Map<Manager.Activities.Contract.Activity>(accessActivity);
        return result;
    }

    public async Task<Contract.Activity> GetActivity(int activityId)
    {
        var accessActivity = await _activitiesAccess.GetActivity(activityId);
        var result = _mapper.Map<Manager.Activities.Contract.Activity>(accessActivity);
        return result;
    }

    public async Task<IEnumerable<Contract.Activity>> GetActivitiesByDateRange(Contract.GetActivitiesInDateRangeRequest getActivitiesInDateRangeRequest)
    {
        var accessGetActivitiesInDateRangeRequest = _mapper.Map<Access.Activities.Contract.GetActivitiesInDateRangeRequest>(getActivitiesInDateRangeRequest);
        var accessActivities = await _activitiesAccess.GetActivitiesInDateRange(accessGetActivitiesInDateRangeRequest);
        var result = _mapper.Map<IEnumerable<Contract.Activity>>(accessActivities);
        return result;
    }
}
