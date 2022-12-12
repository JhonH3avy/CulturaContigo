using CulturaContigo.Api.Common.Integration.Tests.Mothers.Api.Administration;
using CulturaContigo.Api.Controllers.Administration;
using CulturaContigo.Api.Models;

namespace CulturaContigo.Api.Integration.Tests.Controllers.Administration;
internal class Mother
{
    private readonly ActivitiesMother _activitiesMother;

    public Mother()
    {
        _activitiesMother = new ActivitiesMother();
    }

    public ActivityCreateRequest ActivityCreateRequest => _activitiesMother.ActivityCreateRequest;

    internal ActivitiesController CreateAdministrationActivitiesController()
    {
        var result = _activitiesMother.CreateAdministrationActivitiesController();
        return result;
    }
}
