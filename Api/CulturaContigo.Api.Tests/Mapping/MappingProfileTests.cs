using AutoMapper;

namespace CulturaContigo.Api.Tests.Mapping;

[TestFixture]
internal class MappingProfileTests
{
    private IMapper _sut;
    private Mother _mother;

    [SetUp]
    public void SetUp()
    {
        _mother = new Mother();
        _sut = _mother.CreateMapper();
    }

    [Test]
    public void ShouldMapModelActivityCreateRequestToManagerActivityCreateRequest()
    {
        var request = _mother.ModelActivityCreateRequest;

        var actual = _sut.Map<Manager.Activities.Contract.ActivityCreateRequest>(request);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Name, Is.EqualTo(request.Name));
            Assert.That(actual.Details, Is.EqualTo(request.Details));
            Assert.That(actual.ScheduledDateTime, Is.EqualTo(request.ScheduledDateTime));
            Assert.That(actual.Place, Is.EqualTo(request.Place));
            Assert.That(actual.ImageUrl, Is.EqualTo(request.ImageUrl));
            Assert.That(actual.Capacity, Is.EqualTo(request.Capacity));
            Assert.That(actual.TicketPrice, Is.EqualTo(request.TicketPrice));
        });
    }

    [Test]
    public void ShouldMapManagerActivityToModelActivity()
    {
        var request = _mother.ManagerActivity;

        var actual = _sut.Map<Models.Activity>(request);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Id, Is.EqualTo(request.Id));
            Assert.That(actual.Name, Is.EqualTo(request.Name));
            Assert.That(actual.Details, Is.EqualTo(request.Details));
            Assert.That(actual.ScheduledDateTime, Is.EqualTo(request.ScheduledDateTime));
            Assert.That(actual.Place, Is.EqualTo(request.Place));
            Assert.That(actual.ImageUrl, Is.EqualTo(request.ImageUrl));
            Assert.That(actual.Capacity, Is.EqualTo(request.Capacity));
            Assert.That(actual.TicketPrice, Is.EqualTo(request.TicketPrice));
        });
    }

    [Test]
    public void ShouldMapModelActivityCreateRequestToAdministrationManagerActivityCreateRequest()
    {
        var request = _mother.ModelActivityCreateRequest;

        var actual = _sut.Map<Manager.Activities.Administration.Contract.ActivityCreateRequest>(request);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Name, Is.EqualTo(request.Name));
            Assert.That(actual.Details, Is.EqualTo(request.Details));
            Assert.That(actual.ScheduledDateTime, Is.EqualTo(request.ScheduledDateTime));
            Assert.That(actual.Place, Is.EqualTo(request.Place));
            Assert.That(actual.ImageUrl, Is.EqualTo(request.ImageUrl));
            Assert.That(actual.Capacity, Is.EqualTo(request.Capacity));
            Assert.That(actual.TicketPrice, Is.EqualTo(request.TicketPrice));
        });
    }

    [Test]
    public void ShouldMapAdministrationManagerActivityToModelActivity()
    {
        var request = _mother.AdministrationManagerActivity;

        var actual = _sut.Map<Models.Activity>(request);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Id, Is.EqualTo(request.Id));
            Assert.That(actual.Name, Is.EqualTo(request.Name));
            Assert.That(actual.Details, Is.EqualTo(request.Details));
            Assert.That(actual.ScheduledDateTime, Is.EqualTo(request.ScheduledDateTime));
            Assert.That(actual.Place, Is.EqualTo(request.Place));
            Assert.That(actual.ImageUrl, Is.EqualTo(request.ImageUrl));
            Assert.That(actual.Capacity, Is.EqualTo(request.Capacity));
            Assert.That(actual.TicketPrice, Is.EqualTo(request.TicketPrice));
        });
    }

    [Test]
    public void ShouldMapModelPaginationOptionsToManagerPaginationOptions()
    {
        var request = _mother.ModelPaginationOptions;

        var actual = _sut.Map<Manager.Activities.Contract.PaginationOptions>(request);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Page, Is.EqualTo(request.Page));
            Assert.That(actual.Size, Is.EqualTo(request.Size));
        });
    }

    [Test]
    public void ShouldMapModelTicketCreateRequestToManagerTicketCreateRequest()
    {
        var request = _mother.ModelTicketCreateRequest;

        var actual = _sut.Map<Manager.Ticket.Contract.TicketCreateRequest>(request);

        Assert.Multiple(() =>
        {
            Assert.That(actual.PersonalId, Is.EqualTo(request.PersonalId));
            Assert.That(actual.ActivityId, Is.EqualTo(request.ActivityId));
            Assert.That(actual.NumberOfTickets, Is.EqualTo(request.NumberOfTickets));
            Assert.That(actual.TypeOfId, Is.EqualTo(request.TypeOfId));
        });
    }

    [Test]
    public void ShouldMapManagerTicketToModelTicket()
    {
        var request = _mother.ManagerTicket;

        var actual = _sut.Map<Models.Ticket>(request);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Id, Is.EqualTo(request.Id));
            Assert.That(actual.PersonalId, Is.EqualTo(request.PersonalId));
            Assert.That(actual.ActivityId, Is.EqualTo(request.ActivityId));
            Assert.That(actual.NumberOfTickets, Is.EqualTo(request.NumberOfTickets));
            Assert.That(actual.TypeOfId, Is.EqualTo(request.TypeOfId));
        });
    }
}
