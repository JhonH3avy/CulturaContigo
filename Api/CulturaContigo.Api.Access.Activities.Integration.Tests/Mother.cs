using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;

namespace CulturaContigo.Api.Access.Activities.Tests;

internal class Mother
{
    internal IActivitiesAccess CreateActivitiesAccess()
    {
        var result = AccessDependencyBuilder.CreateActivitiesAccess();
        return result;
    }
}