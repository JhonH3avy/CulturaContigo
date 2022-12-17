using AutoMapper;
using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Controllers;
using CulturaContigo.Api.Mapping;

namespace CulturaContigo.Api.Common.Integration.Tests.Mothers.Api;

internal class TicketMother
{
    public TicketController CreateTicketController()
    {
        var mapper = CreateTicketControllerMapper();
        var ticketManager = ManagerDependencyBuilder.CreateTicketManager();
        var result = new TicketController(mapper, ticketManager);
        return result;
    }

    private IMapper CreateTicketControllerMapper()
    {
        var configurationExpression = new MapperConfigurationExpression();
        configurationExpression.AddProfile<MappingProfile>();
        var configuration = new MapperConfiguration(configurationExpression);
        configuration.AssertConfigurationIsValid();
        var result = new Mapper(configuration);
        return result;
    }
}
