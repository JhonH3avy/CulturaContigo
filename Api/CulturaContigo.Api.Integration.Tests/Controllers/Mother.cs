using CulturaContigo.Api.Common.Integration.Tests.Mothers.Api;
using CulturaContigo.Api.Controllers;
using CulturaContigo.Api.Models;

namespace CulturaContigo.Api.Integration.Tests.Controllers;

internal class Mother
{
    private readonly ActivitiesMother _activitiesMother;

    public Mother()
    {
        _activitiesMother = new ActivitiesMother();
    }

    public ActivityCreateRequest ActivityCreateRequest => _activitiesMother.ActivityCreateRequest;

    public PaginationOptions PaginationOptions => new()
    {
        Page = 0,
        Size = 100
    };

    internal ActivitiesController CreateActivitiesController()
    {
        var result = _activitiesMother.CreateActivitiesController();
        return result;
    }

    internal async Task<Activity> CreateActivity(ActivityCreateRequest? activityCreateRequest = null)
    {
        var result = await _activitiesMother.CreateActivity(activityCreateRequest);
        return result;
    }
}
