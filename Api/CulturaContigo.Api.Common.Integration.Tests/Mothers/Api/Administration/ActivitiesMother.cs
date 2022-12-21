using AutoMapper;
using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Controllers.Administration;
using CulturaContigo.Api.Mapping;
using CulturaContigo.Api.Models.Administration;

namespace CulturaContigo.Api.Common.Integration.Tests.Mothers.Api.Administration;

internal class ActivitiesMother
{
    public ActivityCreateRequest ActivityCreateRequest => new()
    {
        Name = "name",
        Place = "place",
        Details = "details",
        Capacity = 100,
        ImageUrl = "imageUrl",
        ScheduledDateTime = DateTime.UtcNow,
        TicketPrice = 10_000m
    };

    internal async Task<Models.Administration.Activity> CreateActivity(ActivityCreateRequest? request = null)
    {
        var administrationActivitiesController = CreateAdministrationActivitiesController();
        var activityCreateRequest = request ?? ActivityCreateRequest;
        var result = await administrationActivitiesController.Post(activityCreateRequest);
        return result;
    }

    internal ActivitiesController CreateAdministrationActivitiesController()
    {
        var activitiesManager = ManagerDependencyBuilder.CreateAdministrationActivitiesManager();
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
