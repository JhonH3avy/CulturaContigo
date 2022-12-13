using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Access.Ticket.Contract;
using CulturaContigo.Api.Common.Integration.Tests.DependencyBuilders;
using CulturaContigo.Api.Common.Integration.Tests.Mothers.Access;

namespace CulturaContigo.Api.Access.Ticket.Integration.Tests;

internal class Mother
{
    private readonly ActivityMother _activityMother;

    public Mother()
    {
        _activityMother = new ActivityMother();
    }

    public TicketCreateRequest TicketCreateRequest(int activityId, int numberOfTickets = 1) => new()
    {
        ActivityId = activityId,
        NumberOfTickets = numberOfTickets,
        PersonalId = "11111111111",
        TypeOfId = "cc"
    };

    internal ITicketAccess CreateTicketAccess()
    {
        var result = AccessDependencyBuilder.CreateTicketAccess();
        return result;
    }

    internal async Task<Activity> CreateActivity()
    {
        var result = await _activityMother.CreateActivity();
        return result;
    }
}