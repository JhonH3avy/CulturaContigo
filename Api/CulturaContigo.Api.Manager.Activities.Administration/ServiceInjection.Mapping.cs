using AutoMapper;

namespace CulturaContigo.Api.Manager.Activities.Administration;

public static partial class ServiceInjection
{
    public static void AddAdministrationActivitiesManagerMappingProfile(this IMapperConfigurationExpression configurationExpression)
    {
        configurationExpression.AddProfile<Mapping.MappingProfile>();
    }
}
