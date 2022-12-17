using CulturaContigo.Api.Access.Activities;
using CulturaContigo.Api.Access.Common;
using CulturaContigo.Api.Access.Ticket;
using CulturaContigo.Api.Manager.Activities;
using CulturaContigo.Api.Manager.Activities.Administration;
using CulturaContigo.Api.Manager.Ticket;

namespace CulturaContigo.Api;

public static partial class ServiceInjection
{

    public static void AddAccessServices(this IServiceCollection services)
    {
        services.AddActivitiesAccessServices();
        services.AddTicketAccessServices();
    }

    public static void AddManagerServices(this IServiceCollection services)
    {
        services.AddActivitiesManagerServices();
        services.AddAdministrationActivitiesManagerServices();
        services.AddTicketManagerServices();
    }

    public static void AddOptionsConfiguration(this IServiceCollection services, IConfigurationRoot configuration)
    {
        var culturaContigoConnectionString = configuration.GetConnectionString(DatabaseConnectionStringsConfiguration.ConnectionStringName);
        var databaseConnectionStringsConfiguration = new DatabaseConnectionStringsConfiguration
        {
            CulturaContigo = culturaContigoConnectionString
        };
        services.AddSingleton(databaseConnectionStringsConfiguration);
    }
}
