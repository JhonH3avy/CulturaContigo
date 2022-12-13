using AutoMapper;
using CulturaContigo.Api.Manager.Activities;
using CulturaContigo.Api.Manager.Activities.Contract;

namespace CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;

internal static class ManagerDependencyBuilder
{
    public static IActivitiesManager CreateActivitiesManager()
    {
        var mapper = CreateActivitiesManagerMapper();
        var activitiesAccess = AccessDependencyBuilder.CreateActivitiesAccess();
        var result = new ActivitiesManager(mapper, activitiesAccess);
        return result;
    }

    public static Manager.Activities.Administration.Contract.IActivitiesManager CreateAdministrationActivitiesManager()
    {
        var mapper = CreateAdministrationActivitiesManagerMapper();
        var activitiesAccess = AccessDependencyBuilder.CreateActivitiesAccess();
        var result = new Manager.Activities.Administration.ActivitiesManager(mapper, activitiesAccess);
        return result;
    }

    public static Manager.Ticket.Contract.ITicketManager CreateTicketManager()
    {
        var mapper = CreateTicketManagerMapper();
        var ticketAccess = AccessDependencyBuilder.CreateTicketAccess();
        var result = new Manager.Ticket.TicketManager(mapper, ticketAccess);
        return result;
    }

    private static IMapper CreateTicketManagerMapper()
    {
        var configurationExpression = new MapperConfigurationExpression();
        configurationExpression.AddProfile<Manager.Ticket.Mapping.MappingProfile>();
        var configuration = new MapperConfiguration(configurationExpression);
        configuration.AssertConfigurationIsValid();
        var result = new Mapper(configuration);
        return result;
    }

    private static IMapper CreateActivitiesManagerMapper()
    {
        var configurationExpression = new MapperConfigurationExpression();
        configurationExpression.AddProfile<Manager.Activities.Mapping.MappingProfile>();
        var configuration = new MapperConfiguration(configurationExpression);
        configuration.AssertConfigurationIsValid();
        var result = new Mapper(configuration);
        return result;
    }

    private static IMapper CreateAdministrationActivitiesManagerMapper()
    {
        var configurationExpression = new MapperConfigurationExpression();
        configurationExpression.AddProfile<Manager.Activities.Administration.Mapping.MappingProfile>();
        var configuration = new MapperConfiguration(configurationExpression);
        configuration.AssertConfigurationIsValid();
        var result = new Mapper(configuration);
        return result;
    }
}
