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

    private static IMapper CreateActivitiesManagerMapper()
    {
        var configurationExpression = new MapperConfigurationExpression();
        configurationExpression.AddProfile<Manager.Activities.Mapping.MappingProfile>();
        var configuration = new MapperConfiguration(configurationExpression);
        configuration.AssertConfigurationIsValid();
        var result = new Mapper(configuration);
        return result;
    }
}
