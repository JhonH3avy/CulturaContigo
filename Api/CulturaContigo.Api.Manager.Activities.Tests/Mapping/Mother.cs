using AutoMapper;
using CulturaContigo.Api.Manager.Activities.Mapping;

namespace CulturaContigo.Api.Manager.Activities.Tests.Mapping;

internal class Mother
{

    public Access.Activities.Contract.Activity AccessActivity => new()
    {
        Id = 100,
        Name = "name",
        Details = "details",
        Capacity = 100,
        ImageUrl = "imageUrl",
        Place = "place",
        ScheduledDateTime = DateTime.UtcNow,
        TicketPrice = 10_000m
    };

    public Manager.Activities.Contract.GetActivitiesInDateRangeRequest ManagerGetActivitiesInDateRangeRequest => new()
    {
        PaginationOptions = ManagerPaginationOptions,
        EndDateTime = DateTime.UtcNow,
        StartDateTime = DateTime.UtcNow
    };

    public Manager.Activities.Contract.PaginationOptions ManagerPaginationOptions => new() 
    {
        Page = 1,
        Size = 100
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
