using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Common.Integration.Tests.Mothers;

namespace CulturaContigo.Api.Access.Activities.Tests;

internal class Mother
{
    private readonly ActivityMother _activityMother;

    public Mother()
    {
        _activityMother = new ActivityMother();
    }

    public PaginationOptions PaginationOptions => new()
    {
        Page = 0,
        Size = 10
    };

    public GetActivitiesInDateRangeRequest GetActivitiesInDateRangeRequest(DateTime startDateTime, DateTime endDateTime) => new()
    {
        PaginationOptions = PaginationOptions,
        StartDateTime = startDateTime,
        EndDateTime = endDateTime
    };

    internal IActivitiesAccess CreateActivitiesAccess()
    {
        var result = AccessDependencyBuilder.CreateActivitiesAccess();
        return result;
    }

    internal async Task<Activity> CreateActivity()
    {
        var result = await _activityMother.CreateActivity();
        return result;
    }
}