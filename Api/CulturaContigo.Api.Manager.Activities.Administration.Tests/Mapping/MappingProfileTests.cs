using AutoMapper;

namespace CulturaContigo.Api.Manager.Activities.Administration.Tests.Mapping;

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
    public void ShouldMapAdministrationManagerActivityCreateRequestToAccessActivityCreateRequest()
    {
        var request = _mother.ManagerActivityCreateRequest;

        var actual = _sut.Map<Access.Activities.Contract.ActivityCreateRequest>(request);

        Assert.That(actual.Name, Is.EqualTo(request.Name));
        Assert.That(actual.Details, Is.EqualTo(request.Details));
        Assert.That(actual.ImageUrl, Is.EqualTo(request.ImageUrl));
        Assert.That(actual.Place, Is.EqualTo(request.Place));
        Assert.That(actual.ScheduledDateTime, Is.EqualTo(request.ScheduledDateTime));
        Assert.That(actual.Capacity, Is.EqualTo(request.Capacity));
        Assert.That(actual.TicketPrice, Is.EqualTo(request.TicketPrice));
    }

    [Test]
    public void ShouldMapAccessActivityToAdministrationManagerActivity()
    {
        var request = _mother.AccessActivity;

        var actual = _sut.Map<Contract.Activity>(request);

        Assert.That(actual.Id, Is.EqualTo(request.Id));
        Assert.That(actual.Name, Is.EqualTo(request.Name));
        Assert.That(actual.Details, Is.EqualTo(request.Details));
        Assert.That(actual.ImageUrl, Is.EqualTo(request.ImageUrl));
        Assert.That(actual.Place, Is.EqualTo(request.Place));
        Assert.That(actual.ScheduledDateTime, Is.EqualTo(request.ScheduledDateTime));
        Assert.That(actual.Capacity, Is.EqualTo(request.Capacity));
        Assert.That(actual.TicketPrice, Is.EqualTo(request.TicketPrice));
    }
}
