using AutoMapper;

namespace CulturaContigo.Api.Manager.Activities;

public static partial class ServiceInjection
{
    public static void AddActivitiesManagerMappingProfile(this IMapperConfigurationExpression configurationExpression)
    {
        configurationExpression.AddProfile<Mapping.MappingProfile>();
    }
}
