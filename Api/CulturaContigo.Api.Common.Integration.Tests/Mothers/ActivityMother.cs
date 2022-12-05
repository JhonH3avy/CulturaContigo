using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;

namespace CulturaContigo.Api.Common.Integration.Tests.Mothers;

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

	public async Task<Activity> CreateActivity()
	{
		var result = await _activitiesAccess.CreateActivity(ActivityCreateRequest);
		return result;
	}
}
