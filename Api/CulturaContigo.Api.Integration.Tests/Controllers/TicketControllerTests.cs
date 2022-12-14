using CulturaContigo.Api.Controllers;

namespace CulturaContigo.Api.Integration.Tests.Controllers;

[TestFixture]
[Category("Integration")]
public class TicketControllerTests
{
    private TicketController _sut;
    private Mother _mother;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mother = new Mother();
    }

    [SetUp]
    public void SetUp()
    {
        _sut = _mother.CreateTicketController();
    }

    [Test]
    public async Task ShouldPost()
    {
        var activity = await _mother.CreateActivity();
        var ticketCreateRequest = _mother.TicketCreateRequest(activity.Id);

        var actual = await _sut.Post(ticketCreateRequest);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Id, Is.Not.Zero);
            Assert.That(actual.ActivityId, Is.EqualTo(ticketCreateRequest.ActivityId));
            Assert.That(actual.PersonalId, Is.EqualTo(ticketCreateRequest.PersonalId));
            Assert.That(actual.NumberOfTickets, Is.EqualTo(ticketCreateRequest.NumberOfTickets));
            Assert.That(actual.TypeOfId, Is.EqualTo(ticketCreateRequest.TypeOfId));
        });
    }
}
