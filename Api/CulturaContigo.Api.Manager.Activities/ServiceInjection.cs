using CulturaContigo.Api.Manager.Activities.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace CulturaContigo.Api.Manager.Activities;

public static partial class ServiceInjection
{
    public static void AddActivitiesManagerServices(this IServiceCollection services)
    {
        services.AddTransient<IActivitiesManager, ActivitiesManager>();
    }
}
