using CulturaContigo.Api.Manager.Ticket.Contract;

namespace CulturaContigo.Api.Manager.Ticket.Integration.Tests;

[TestFixture]
[Category("Integration")]
public class TicketManagerTests
{
    private ITicketManager _sut;
    private Mother _mother;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mother = new Mother();
    }

    [SetUp]
    public void SetUp()
    {
        _sut = _mother.CreateTicketManager();
    }

    [Test]
    public async Task ShouldCreateTicket()
    {
        var activity = await _mother.CreateActivity();
        var ticketCreateRequest = _mother.TicketCreateRequest(activity.Id);

        var actual = await _sut.CreateTicket(ticketCreateRequest);

        Assert.That(actual.Id, Is.Not.Zero);
        Assert.That(actual.PersonalId, Is.EqualTo(ticketCreateRequest.PersonalId));
        Assert.That(actual.ActivityId, Is.EqualTo(activity.Id));
        Assert.That(actual.NumberOfTickets, Is.EqualTo(ticketCreateRequest.NumberOfTickets));
        Assert.That(actual.TypeOfId, Is.EqualTo(ticketCreateRequest.TypeOfId));
    }
}
