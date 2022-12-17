using AutoMapper;

namespace CulturaContigo.Api.Manager.Ticket.Tests.Mapping;

[TestFixture]
public class MappingProfileTests
{
    private IMapper _sut;
    private Mother _mother;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mother = new Mother();
    }

    [SetUp]
    public void SetUp()
    {
        _sut = _mother.CreateMapper();
    }

    [Test]
    public void ShouldMapManagerTicketCreateRequestToAccessTicketCreateRequest()
    {
        var request = _mother.ManagerTicketCreateRequest;

        var actual = _sut.Map<Access.Ticket.Contract.TicketCreateRequest>(request);
        
        Assert.Multiple(() =>
        {
            Assert.That(actual.PersonalId, Is.EqualTo(request.PersonalId));
            Assert.That(actual.ActivityId, Is.EqualTo(request.ActivityId));
            Assert.That(actual.TypeOfId, Is.EqualTo(request.TypeOfId));
            Assert.That(actual.NumberOfTickets, Is.EqualTo(request.NumberOfTickets));
        });
    }

    [Test]
    public void ShouldMapAccessTicketToManagerTicket()
    {
        var request = _mother.AccessTicket;

        var actual = _sut.Map<Contract.Ticket>(request);
        
        Assert.Multiple(() =>
        {
            Assert.That(actual.Id, Is.EqualTo(request.Id));
            Assert.That(actual.PersonalId, Is.EqualTo(request.PersonalId));
            Assert.That(actual.ActivityId, Is.EqualTo(request.ActivityId));
            Assert.That(actual.TypeOfId, Is.EqualTo(request.TypeOfId));
            Assert.That(actual.NumberOfTickets, Is.EqualTo(request.NumberOfTickets));
        });
    }
}
