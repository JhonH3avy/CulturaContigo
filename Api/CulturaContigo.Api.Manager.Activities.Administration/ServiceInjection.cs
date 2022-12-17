using CulturaContigo.Api.Manager.Activities.Administration.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace CulturaContigo.Api.Manager.Activities.Administration;

public static partial class ServiceInjection
{
    public static void AddAdministrationActivitiesManagerServices(this IServiceCollection services)
    {
        services.AddTransient<IActivitiesManager, ActivitiesManager>();
    }
}
