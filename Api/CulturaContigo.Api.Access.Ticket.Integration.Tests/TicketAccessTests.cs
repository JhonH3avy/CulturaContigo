using CulturaContigo.Api.Access.Ticket.Contract;

namespace CulturaContigo.Api.Access.Ticket.Integration.Tests;

[TestFixture]
[Category("Integration")]
public class TicketAccessTests
{
    private ITicketAccess _sut;
    private Mother _mother;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mother = new Mother();
    }

    [SetUp]
    public void SetUp()
    {
        _sut = _mother.CreateTicketAccess();
    }

    [Test]
    public async Task ShouldCreateTicket()
    {
        var activity = await _mother.CreateActivity();
        var ticketCreateRequest = _mother.TicketCreateRequest(activity.Id);

        var actual = await _sut.CreateTicket(ticketCreateRequest);
        
        Assert.Multiple(() =>
        {
            Assert.That(actual.Id, Is.Not.Zero);
            Assert.That(actual.PersonalId, Is.EqualTo(ticketCreateRequest.PersonalId));
            Assert.That(actual.ActivityId, Is.EqualTo(ticketCreateRequest.ActivityId));
            Assert.That(actual.NumberOfTickets, Is.EqualTo(ticketCreateRequest.NumberOfTickets));
        });

        _mother.AddActivitiesForCleanUp(activity.Id);
    }
}
