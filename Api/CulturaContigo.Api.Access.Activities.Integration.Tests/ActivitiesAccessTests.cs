using CulturaContigo.Api.Access.Activities.Contract;

namespace CulturaContigo.Api.Access.Activities.Integration.Tests;

[TestFixture]
[Category("Integration")]
public class ActivitiesAccessTests
{
    private IActivitiesAccess _sut;
    private Mother _mother;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mother = new Mother();
    }

    [SetUp]
    public void Setup()
    {
        _sut = _mother.CreateActivitiesAccess();
    }

    [Test]
    public async Task ShouldCreateActivity()
    {
        var activityCreateRequest = _mother.ActivityCreateRequest;

        var actual = await _sut.CreateActivity(activityCreateRequest);

        Assert.That(actual.Id, Is.Not.Zero);
        Assert.That(actual.Name, Is.EqualTo(activityCreateRequest.Name));
        Assert.That(actual.Details, Is.EqualTo(activityCreateRequest.Details));
        Assert.That(actual.ImageUrl, Is.EqualTo(activityCreateRequest.ImageUrl));
        Assert.That(actual.Capacity, Is.EqualTo(activityCreateRequest.Capacity));
        Assert.That(actual.Available, Is.EqualTo(activityCreateRequest.Capacity));
        Assert.That(actual.TicketPrice, Is.EqualTo(activityCreateRequest.TicketPrice));
        Assert.That(actual.ScheduledDateTime, Is.EqualTo(activityCreateRequest.ScheduledDateTime));
        Assert.That(actual.Place, Is.EqualTo(activityCreateRequest.Place));
    }

    [Test]
    public async Task ShouldGetActivity()
    {
        var expectedActivity = await _mother.CreateActivity();

        var actual = await _sut.GetActivity(expectedActivity.Id);

        Assert.That(actual.Id, Is.EqualTo(expectedActivity.Id));
        Assert.That(actual.Name, Is.EqualTo(expectedActivity.Name));
        Assert.That(actual.Details, Is.EqualTo(expectedActivity.Details));
        Assert.That(actual.ImageUrl, Is.EqualTo(expectedActivity.ImageUrl));
        Assert.That(actual.Capacity, Is.EqualTo(expectedActivity.Capacity));
        Assert.That(actual.Available, Is.EqualTo(expectedActivity.Capacity));
        Assert.That(actual.TicketPrice, Is.EqualTo(expectedActivity.TicketPrice));
        Assert.That(actual.ScheduledDateTime, Is.EqualTo(expectedActivity.ScheduledDateTime));
        Assert.That(actual.Place, Is.EqualTo(expectedActivity.Place));
    }

    [Test]
    public async Task ShouldGetActivitiesInDateRange()
    {
        var startDate = DateTime.UtcNow;
        var activity1 = await _mother.CreateActivity();
        var activity2 = await _mother.CreateActivity();
        var activity3 = await _mother.CreateActivity();
        var activity4 = await _mother.CreateActivity();
        var endDate = DateTime.UtcNow;
        var expectedActivitiesIds = new[] { activity1.Id, activity2.Id, activity3.Id, activity4.Id };
        var getActivitiesInDateRangeRequest = _mother.GetActivitiesInDateRangeRequest(startDate, endDate);

        var actual = await _sut.GetActivitiesInDateRange(getActivitiesInDateRangeRequest);

        Assert.That(actual, Has.Exactly(4).Items);
        Assert.That(actual.Select(x => x.Id), Is.EquivalentTo(expectedActivitiesIds));
    }
}
