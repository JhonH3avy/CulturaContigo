using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;

namespace CulturaContigo.Api.Common.Integration.Tests.Mothers.Access;

internal class ActivityMother
{
    private readonly IActivitiesAccess _activitiesAccess;

    public ActivityMother()
    {
        _activitiesAccess = AccessDependencyBuilder.CreateActivitiesAccess();
    }

    public ActivityCreateRequest ActivityCreateRequest => new()
    {
        Name = "name",
        Details = "details",
        Capacity = 100,
        ImageUrl = "imageUrl",
        Place = "place",
        ScheduledDateTime = DateTime.UtcNow,
        TicketPrice = 10_000m
    };

    public async Task<Activity> CreateActivity(ActivityCreateRequest? activityCreateRequest = null)
    {
        var request = activityCreateRequest ?? ActivityCreateRequest;
        var result = await _activitiesAccess.CreateActivity(request);
        return result;
    }

    public async Task DeleteActivity(int activityId)
    {
        await _activitiesAccess.DeleteActivity(activityId);
    }
}
