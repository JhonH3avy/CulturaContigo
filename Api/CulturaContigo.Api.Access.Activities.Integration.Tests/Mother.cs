using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Common.Integration.Tests.Mothers.Access;

namespace CulturaContigo.Api.Access.Activities.Integration.Tests;

internal class Mother
{
    private readonly ActivityMother _activityMother;

    private readonly IList<int> _activitiesToDelete;

    public Mother()
    {
        _activityMother = new ActivityMother();
        _activitiesToDelete = new List<int>();
    }

    public PaginationOptions PaginationOptions => new()
    {
        Page = 0,
        Size = 10
    };

    public ActivityCreateRequest ActivityCreateRequest => _activityMother.ActivityCreateRequest;

    public GetActivitiesInDateRangeRequest GetActivitiesInDateRangeRequest(DateTime startDateTime, DateTime endDateTime) => new()
    {
        PaginationOptions = PaginationOptions,
        StartDateTime = startDateTime,
        EndDateTime = endDateTime
    };

    internal void AddActivitiesForCleanUp(params int[] activityIds)
    {
        foreach (int activityId in activityIds)
        {
            _activitiesToDelete.Add(activityId);
        }
    }

    internal IActivitiesAccess CreateActivitiesAccess()
    {
        var result = AccessDependencyBuilder.CreateActivitiesAccess();
        return result;
    }

    internal async Task<Activity> CreateActivity(ActivityCreateRequest? activityCreateRequest)
    {
        var result = await _activityMother.CreateActivity(activityCreateRequest);
        return result;
    }

    internal async Task<IEnumerable<Activity>> CreateMultipleActivities(DateTime scheduledDateTime, int activitiesCount = 20)
    {
        var result = new List<Activity>();
        for (var i = 0; i < activitiesCount; i++)
        {
            var request = _activityMother.ActivityCreateRequest with { ScheduledDateTime = scheduledDateTime };
            var activity = await CreateActivity(request);
            result.Add(activity);
        }
        return result;
    }

    internal async Task DeleteActivitiesForCleanUp()
    {
        foreach (var activityId in _activitiesToDelete)
        {
            await _activityMother.DeleteActivity(activityId);
        }
    }
}