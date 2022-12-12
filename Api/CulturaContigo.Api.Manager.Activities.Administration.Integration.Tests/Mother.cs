using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Common.Integration.Tests.Mothers.Manager.Administration;
using CulturaContigo.Api.Manager.Activities.Administration.Contract;

namespace CulturaContigo.Api.Manager.Activities.Administration.Integration.Tests;

internal class Mother
{
    private readonly ActivityMother _activityMother;

    public Mother()
    {
        _activityMother = new ActivityMother();
    }

    public ActivityCreateRequest ActivityCreateRequest => _activityMother.ActivityCreateRequest;

    internal IActivitiesManager CreateActivitiesManager()
    {
        var result = ManagerDependencyBuilder.CreateAdministrationActivitiesManager();
        return result;
    }
}