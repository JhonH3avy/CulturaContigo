using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Common.Integration.Tests.Mothers.Manager.Administration;
using CulturaContigo.Api.Manager.Activities.Administration.Contract;

namespace CulturaContigo.Api.Manager.Activities.Administration.Integration.Tests;

internal class Mother
{
    private readonly ActivityMother _activityMother;

    public Mother()
    {
        _activityMother = new ActivityMother();
    }

    public ActivityCreateRequest ActivityCreateRequest => _activityMother.ActivityCreateRequest;

    public PaginationOptions PaginationOptions => new()
    {
        Size = 10,
        Page = 0
    };

    internal IActivitiesManager CreateActivitiesManager()
    {
        var result = ManagerDependencyBuilder.CreateAdministrationActivitiesManager();
        return result;
    }

    internal async Task<IEnumerable<Activity>> CreateMultipleActivities(ActivityCreateRequest? activityCreateRequest = null, int amountOfActivities = 20)
    {
        var result = new List<Activity>();
        for (var i = 0; i < amountOfActivities; i++)
        {
            var activity = await _activityMother.CreateActivity(activityCreateRequest);
            result.Add(activity);
        }
        return result;
    }
}