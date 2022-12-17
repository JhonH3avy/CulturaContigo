using AutoMapper;
using CulturaContigo.Api.Mapping;
using CulturaContigo.Api.Models.Administration;

namespace CulturaContigo.Api.Tests.Mapping;

internal class Mother
{
    public ActivityCreateRequest ModelActivityCreateRequest => new()
    {
        Name = "name",
        Details = "details",
        Capacity = 100,
        Place = "place",
        ImageUrl = "imageurl",
        ScheduledDateTime = DateTime.Now,
        TicketPrice = 10_000m
    };

    public Manager.Activities.Contract.Activity ManagerActivity => new()
    {
        Id = 100,
        Name = "name",
        Details = "details",
        Capacity = 100,
        Place = "place",
        ImageUrl = "imageurl",
        ScheduledDateTime = DateTime.Now,
        TicketPrice = 10_000m
    };

    public Models.PaginationOptions ModelPaginationOptions => new()
    {
        Page = 1,
        Size = 100
    };

    public Manager.Activities.Administration.Contract.Activity AdministrationManagerActivity => new()
    {
        Id = 100,
        Name = "name",
        Details = "details",
        Capacity = 100,
        Place = "place",
        ImageUrl = "imageurl",
        ScheduledDateTime = DateTime.Now,
        TicketPrice = 10_000m
    };

    public Models.TicketCreateRequest ModelTicketCreateRequest => new()
    {
        ActivityId  = 10,
        NumberOfTickets = 5,
        PersonalId = "personalId",
        TypeOfId = "typeOfid"
    };

    public Manager.Ticket.Contract.Ticket ManagerTicket => new()
    {
        Id = 100,
        ActivityId = 10,
        NumberOfTickets = 5,
        PersonalId = "personalId",
        TypeOfId = "typeOfid"
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
