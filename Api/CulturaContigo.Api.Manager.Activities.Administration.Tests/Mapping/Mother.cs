using AutoMapper;
using CulturaContigo.Api.Manager.Activities.Administration.Mapping;

namespace CulturaContigo.Api.Manager.Activities.Administration.Tests.Mapping;

internal class Mother
{
    public Manager.Activities.Administration.Contract.ActivityCreateRequest ManagerActivityCreateRequest => new()
    {
        Name = "name",
        Details = "details",
        Capacity = 100,
        ImageUrl = "imageUrl",
        Place = "place",
        ScheduledDateTime = DateTime.UtcNow,
        TicketPrice = 10_000m
    };

    public Access.Activities.Contract.Activity AccessActivity => new()
    {
        Id = 10,
        Name = "name",
        Details = "details",
        Capacity = 100,
        ImageUrl = "imageUrl",
        Place = "place",
        ScheduledDateTime = DateTime.UtcNow,
        TicketPrice = 10_000m
    };

    internal IMapper CreateMapper()
    {
        var configurationExpression = new MapperConfigurationExpression();
        configurationExpression.AddProfile<MappingProfile>();
        var configuration = new MapperConfiguration(configurationExpression);
        configuration.AssertConfigurationIsValid();
        var result = new Mapper(configuration);
        return result;
    }
}
