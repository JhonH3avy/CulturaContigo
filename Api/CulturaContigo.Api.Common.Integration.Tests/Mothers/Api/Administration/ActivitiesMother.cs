using AutoMapper;
using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Controllers.Administration;
using CulturaContigo.Api.Mapping;

namespace CulturaContigo.Api.Common.Integration.Tests.Mothers.Api.Administration;

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
