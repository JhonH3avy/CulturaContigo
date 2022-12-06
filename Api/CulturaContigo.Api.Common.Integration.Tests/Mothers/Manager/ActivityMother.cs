using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Manager.Activities.Contract;

namespace CulturaContigo.Api.Common.Integration.Tests.Mothers.Manager;
internal class ActivityMother
{
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

    internal async Task<Activity> CreateActivity()
    {
        var activitiesManager = ManagerDependencyBuilder.CreateActivitiesManager();
        var result = await activitiesManager.CreateActivity(ActivityCreateRequest);
        return result;
    }
}
