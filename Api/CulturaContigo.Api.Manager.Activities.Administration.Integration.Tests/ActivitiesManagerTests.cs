using CulturaContigo.Api.Manager.Activities.Administration.Contract;

namespace CulturaContigo.Api.Manager.Activities.Administration.Integration.Tests;

[TestFixture]
[Category("Integration")]
public class ActivitiesManagerTests
{
    private IActivitiesManager _sut;
    private Mother _mother;

    [SetUp]
    public void Setup()
    {
        _mother = new Mother();
        _sut = _mother.CreateActivitiesManager();
    }

    [Test]
    public async Task ShouldCreateActivity()
    {
        var activityCreateRequest = _mother.ActivityCreateRequest;

        var actual = await _sut.CreateActivity(activityCreateRequest);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Id, Is.Not.Zero);
            Assert.That(actual.Name, Is.EqualTo(activityCreateRequest.Name));
            Assert.That(actual.Details, Is.EqualTo(activityCreateRequest.Details));
            Assert.That(actual.ImageUrl, Is.EqualTo(activityCreateRequest.ImageUrl));
            Assert.That(actual.Capacity, Is.EqualTo(activityCreateRequest.Capacity));
            Assert.That(actual.Available, Is.EqualTo(activityCreateRequest.Capacity));
            Assert.That(actual.TicketPrice, Is.EqualTo(activityCreateRequest.TicketPrice));
            Assert.That(actual.ScheduledDateTime, Is.EqualTo(activityCreateRequest.ScheduledDateTime));
            Assert.That(actual.Place, Is.EqualTo(activityCreateRequest.Place));
        });
    }

    [Test]
    public async Task ShouldGetActivitiesAfterDate()
    {
        var startDate = DateTime.UtcNow;
        var activityCreateRequest = _mother.ActivityCreateRequest with { ScheduledDateTime = startDate.AddMilliseconds(1) };
        var activities = await _mother.CreateMultipleActivities(activityCreateRequest);
        var paginationOptions = _mother.PaginationOptions;

        var actual = await _sut.GetActivitiesAfterDate(startDate, paginationOptions);

        Assert.That(actual.Select(x => x.Id), Is.SubsetOf(activities.Select(x => x.Id)));
    }

    [Test]
    public async Task ShouldGetActivitiesBeforeDate()
    {
        var startDate = DateTime.UtcNow;
        var activityCreateRequest = _mother.ActivityCreateRequest with { ScheduledDateTime = startDate.AddMilliseconds(-1) };
        var activities = await _mother.CreateMultipleActivities(activityCreateRequest);
        var paginationOptions = _mother.PaginationOptions;

        var actual = await _sut.GetActivitiesBeforeDate(startDate, paginationOptions);

        Assert.That(actual.Select(x => x.Id), Is.SubsetOf(activities.Select(x => x.Id)));
    }
}
