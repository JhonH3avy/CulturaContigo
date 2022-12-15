using AutoMapper;

namespace CulturaContigo.Api.Manager.Activities.Tests.Mapping;

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
    public void ShouldMapManagerActivityCreateRequestToAccessActivityCreateRequest()
    {
        var request = _mother.ManagerActivityCreateRequest;

        var actual = _sut.Map<Access.Activities.Contract.ActivityCreateRequest>(request);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Name, Is.EqualTo(request.Name));
            Assert.That(actual.Details, Is.EqualTo(request.Details));
            Assert.That(actual.Place, Is.EqualTo(request.Place));
            Assert.That(actual.ImageUrl, Is.EqualTo(request.ImageUrl));
            Assert.That(actual.ScheduledDateTime, Is.EqualTo(request.ScheduledDateTime));
            Assert.That(actual.Capacity, Is.EqualTo(request.Capacity));
            Assert.That(actual.TicketPrice, Is.EqualTo(request.TicketPrice));
        });
    }

    [Test]
    public void ShouldMapAccessActivityToManagerActivity()
    {
        var request = _mother.AccessActivity;

        var actual = _sut.Map<Manager.Activities.Contract.Activity>(request);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Id, Is.EqualTo(request.Id));
            Assert.That(actual.Name, Is.EqualTo(request.Name));
            Assert.That(actual.Details, Is.EqualTo(request.Details));
            Assert.That(actual.Place, Is.EqualTo(request.Place));
            Assert.That(actual.ImageUrl, Is.EqualTo(request.ImageUrl));
            Assert.That(actual.ScheduledDateTime, Is.EqualTo(request.ScheduledDateTime));
            Assert.That(actual.Capacity, Is.EqualTo(request.Capacity));
            Assert.That(actual.TicketPrice, Is.EqualTo(request.TicketPrice));
        });
    }

    [Test]
    public void ShouldManagerPaginationOptionsToAccessPaginationOptions()
    {
        var request = _mother.ManagerPaginationOptions;

        var actual = _sut.Map<Access.Activities.Contract.PaginationOptions>(request);
        
        Assert.Multiple(() =>
        {
            Assert.That(actual.Page, Is.EqualTo(request.Page));
            Assert.That(actual.Size, Is.EqualTo(request.Size));
        });
    }

    [Test]
    public void ShouldMapManagerGetActivitiesInDateRangeRequestToAccessGetActivitiesInDaterangeRequest()
    {
        var request = _mother.ManagerGetActivitiesInDateRangeRequest;

        var actual = _sut.Map<Access.Activities.Contract.GetActivitiesInDateRangeRequest>(request);
        
        Assert.Multiple(() =>
        {
            Assert.That(actual.StartDateTime, Is.EqualTo(request.StartDateTime));
            Assert.That(actual.EndDateTime, Is.EqualTo(request.EndDateTime));
        });
    }
}
