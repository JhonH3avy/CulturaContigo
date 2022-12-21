using CulturaContigo.Api.Common.Integration.Tests.Mothers.Api;
using CulturaContigo.Api.Controllers;
using CulturaContigo.Api.Models;
using CulturaContigo.Api.Models.Administration;

namespace CulturaContigo.Api.Integration.Tests.Controllers;

internal class Mother
{
    private readonly Common.Integration.Tests.Mothers.Api.Administration.ActivitiesMother _administrationActivitiesMother;
    private readonly ActivitiesMother _activitiesMother;
    private readonly TicketMother _ticketMother;

    public Mother()
    {
        _administrationActivitiesMother = new Common.Integration.Tests.Mothers.Api.Administration.ActivitiesMother();
        _ticketMother = new TicketMother();
        _activitiesMother = new ActivitiesMother();
    }

    public ActivityCreateRequest ActivityCreateRequest => _activitiesMother.ActivityCreateRequest;

    public PaginationOptions PaginationOptions => new()
    {
        Page = 0,
        Size = 100
    };

    internal ActivitiesController CreateActivitiesController()
    {
        var result = _activitiesMother.CreateActivitiesController();
        return result;
    }

    internal async Task<Models.Administration.Activity> CreateActivity(ActivityCreateRequest? activityCreateRequest = null)
    {
        var result = await _administrationActivitiesMother.CreateActivity(activityCreateRequest);
        return result;
    }

    internal TicketController CreateTicketController()
    {
        var result = _ticketMother.CreateTicketController();
        return result;
    }

    internal TicketCreateRequest TicketCreateRequest(int activityId) => new()
    {
        ActivityId = activityId,
        NumberOfTickets = 1,
        PersonalId = "personalId",
        TypeOfId = "typeOfId"
    };
}
