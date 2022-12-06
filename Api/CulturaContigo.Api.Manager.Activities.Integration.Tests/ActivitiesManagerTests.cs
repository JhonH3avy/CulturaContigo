using CulturaContigo.Api.Manager.Activities.Contract;

namespace CulturaContigo.Api.Manager.Activities.Integration.Tests;

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
        var startDateTime = DateTime.UtcNow;
        var expectedActivity1 = await _mother.CreateActivity();
        var expectedActivity2 = await _mother.CreateActivity();
        var expectedActivity3 = await _mother.CreateActivity();
        var expectedActivity4 = await _mother.CreateActivity();
        var endDateTime = DateTime.UtcNow;
        var getActivitiesInDateRangeRequest = _mother.GetActivitiesInDateRangeRequest(startDateTime, endDateTime);
        var expectedActivitriesids = new[] {expectedActivity1.Id, expectedActivity2.Id, expectedActivity3.Id, expectedActivity4.Id}; 

        var actual = await _sut.GetActivitiesByDateRange(getActivitiesInDateRangeRequest);

        Assert.That(actual, Has.Exactly(4).Items);
        Assert.That(actual.Select(x => x.Id), Is.EqualTo(expectedActivitriesids));
    }
}
