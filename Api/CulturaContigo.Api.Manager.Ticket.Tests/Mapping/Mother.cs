using AutoMapper;
using CulturaContigo.Api.Manager.Ticket.Mapping;

namespace CulturaContigo.Api.Manager.Ticket.Tests.Mapping;

internal class Mother
{
    public Contract.TicketCreateRequest ManagerTicketCreateRequest => new()
    {
        ActivityId = 100,
        NumberOfTickets = 5,
        PersonalId = "11111111111",
        TypeOfId = "cc"
    };

    public Access.Ticket.Contract.Ticket AccessTicket => new()
    {
        Id = 10,
        ActivityId = 100,
        NumberOfTickets = 5,
        PersonalId = "11111111111",
        TypeOfId = "cc"
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