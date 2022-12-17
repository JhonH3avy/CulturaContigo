using AutoMapper;
using CulturaContigo.Api.Manager.Activities;
using CulturaContigo.Api.Manager.Activities.Administration;
using CulturaContigo.Api.Manager.Ticket;

namespace CulturaContigo.Api;

public static partial class ServiceInjection
{
    public static void AddMapper(this IServiceCollection services)
    {        
        services.AddScoped<IMapper>(serviceProvider =>
        {
            var configurationExpression = new MapperConfigurationExpression();
            configurationExpression.AddActivitiesManagerMappingProfile();
            configurationExpression.AddAdministrationActivitiesManagerMappingProfile();
            configurationExpression.AddTicketManagerMappingProfile();
            configurationExpression.AddProfile<Mapping.MappingProfile>();
            var configuration = new MapperConfiguration(configurationExpression);
            var result = new Mapper(configuration);
            return result;
        });
    }
}
