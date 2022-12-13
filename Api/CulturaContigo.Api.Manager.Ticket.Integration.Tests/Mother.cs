using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Common.Integration.Tests.Mothers.Manager;
using CulturaContigo.Api.Manager.Activities.Contract;
using CulturaContigo.Api.Manager.Ticket.Contract;

namespace CulturaContigo.Api.Manager.Ticket.Integration.Tests;

internal class Mother
{
    private readonly ActivityMother _activityMother;

    public Mother()
    {
        _activityMother = new ActivityMother();
    }

    internal Task<Activity> CreateActivity()
    {
        var result = _activityMother.CreateActivity();
        return result;
    }

    internal ITicketManager CreateTicketManager()
    {
        var result = ManagerDependencyBuilder.CreateTicketManager();
        return result;
    }

    internal TicketCreateRequest TicketCreateRequest(int activityId) => new()
    {
        ActivityId = activityId,
        NumberOfTickets = 1,
        PersonalId = "11111111",
        TypeOfId = "cc"
    };
}