using CulturaContigo.Api.Controllers;

namespace CulturaContigo.Api.Integration.Tests.Controllers;

[TestFixture]
[Category("Integration")]
public class ActivitiesControllerTests
{
    private ActivitiesController _sut;
    private Mother _mother;

    [SetUp]
    public void SetUp()
    {
        _mother = new Mother();
        _sut = _mother.CreateActivitiesController();
    }

    [Test]
    public async Task ShouldPost()
    {
        var activityCreateRequest = _mother.ActivityCreateRequest;

        var actual = await _sut.Post(activityCreateRequest);

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
    public async Task ShouldGet()
    {
        var expectedActivity = await _mother.CreateActivity();

        var actual = await _sut.Get(expectedActivity.Id);

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
}
