using CulturaContigo.Api.Access.Activities;
using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Access.Common;
using CulturaContigo.Api.Access.Ticket;
using CulturaContigo.Api.Access.Ticket.Contract;
using Microsoft.Extensions.Configuration;

namespace CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;

internal static class AccessDependencyBuilder
{
    private const string CulturaContigoDbConnectionStringSection = "CulturaContigo.Db";

    public static IActivitiesAccess CreateActivitiesAccess()
    {
        var databaseConnectionStringsConfiguration = GetDatabaseConnectionStringsConfiguration();
        var result = new ActivitiesAccess(databaseConnectionStringsConfiguration);
        return result;
    }

    public static ITicketAccess CreateTicketAccess()
    {
        var databaseConnectionStringsConfiguration = GetDatabaseConnectionStringsConfiguration();
        var result = new TicketAccess(databaseConnectionStringsConfiguration);
        return result;
    }

    private static DatabaseConnectionStringsConfiguration GetDatabaseConnectionStringsConfiguration()
    {
        var configurationRoot = AppSettingsConfigurationDependencyBuilder.CreateConfigurationRoot();
        var culturaContigoConnectionString = configurationRoot.GetConnectionString(CulturaContigoDbConnectionStringSection);
        var databaseConnectionStringsConfiguration = new DatabaseConnectionStringsConfiguration
        {
            CulturaContigo = culturaContigoConnectionString
        };
        return databaseConnectionStringsConfiguration;
    }
}
