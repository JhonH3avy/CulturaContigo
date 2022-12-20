﻿using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Manager.Activities.Administration.Contract;

namespace CulturaContigo.Api.Common.Integration.Tests.Mothers.Manager.Administration;

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

    internal async Task<Activity> CreateActivity(ActivityCreateRequest? activityCreateRequest)
    {
        var activitiesManager = ManagerDependencyBuilder.CreateAdministrationActivitiesManager();
        var request = activityCreateRequest ?? ActivityCreateRequest;
        var result = await activitiesManager.CreateActivity(request);
        return result;
    }
}
