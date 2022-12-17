using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Common.Integration.Tests.Mothers.Manager.Administration;
using CulturaContigo.Api.Manager.Activities.Contract;

namespace CulturaContigo.Api.Manager.Activities.Integration.Tests;

internal class Mother
{
    private readonly ActivityMother _activityMother;

    public Mother()
    {
        _activityMother = new ActivityMother();
    }

    public Administration.Contract.ActivityCreateRequest ActivityCreateRequest => _activityMother.ActivityCreateRequest;

    public GetActivitiesInDateRangeRequest GetActivitiesInDateRangeRequest(DateTime startDateTime, DateTime endDateTime) => new()
    {
        PaginationOptions = new()
        {
            Page = 0,
            Size = 10
        },
        StartDateTime = startDateTime,
        EndDateTime = endDateTime
    };

    internal IActivitiesManager CreateActivitiesManager()
    {
        var result = ManagerDependencyBuilder.CreateActivitiesManager();
        return result;
    }

    internal async Task<Administration.Contract.Activity> CreateActivity()
    {
        var result = await _activityMother.CreateActivity();
        return result;
    }
}