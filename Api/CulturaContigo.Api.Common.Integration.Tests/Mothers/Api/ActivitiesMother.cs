using AutoMapper;
using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Controllers;
using CulturaContigo.Api.Mapping;
using CulturaContigo.Api.Models;

namespace CulturaContigo.Api.Common.Integration.Tests.Mothers.Api;

internal class ActivitiesMother
{
    public Models.ActivityCreateRequest ActivityCreateRequest => new()
    {
        Name = "name",
        Place = "place",
        Details = "details",
        Capacity = 100,
        ImageUrl = "imageUrl",
        ScheduledDateTime = DateTime.UtcNow,
        TicketPrice = 10_000m
    };

    public async Task<Activity> CreateActivity()
    {
        var activitiesController = CreateActivitiesController();
        var result = await activitiesController.Post(ActivityCreateRequest);
        return result;
    }

    internal ActivitiesController CreateActivitiesController()
    {
        var activitiesManager = ManagerDependencyBuilder.CreateActivitiesManager();
        var mapper = CreateMapper();
        var result = new ActivitiesController(mapper, activitiesManager);
        return result;
    }
    private IMapper CreateMapper()
    {
        var configurationExpression = new MapperConfigurationExpression();
        configurationExpression.AddProfile<MappingProfile>();
        var configuration = new MapperConfiguration(configurationExpression);
        configuration.AssertConfigurationIsValid();
        var result = new Mapper(configuration);
        return result;
    }

}
