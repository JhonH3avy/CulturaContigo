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
}
