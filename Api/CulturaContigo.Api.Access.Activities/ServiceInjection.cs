using CulturaContigo.Api.Access.Activities.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace CulturaContigo.Api.Access.Activities;

public static partial class ServiceInjection
{
    public static void AddActivitiesAccessServices(this IServiceCollection services)
    {
        services.AddTransient<IActivitiesAccess, ActivitiesAccess>();
    }
}
