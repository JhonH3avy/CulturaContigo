using CulturaContigo.Api.Access.Activities.Contract;

namespace CulturaContigo.Api.Access.Activities.Tests;

public class ActivitiesAccessTests
{
    private IActivitiesAccess _sut;
    private Mother _mother;

    [SetUp]
    public void Setup()
    {
        _mother = new Mother();
        _sut = _mother.CreateActivitiesAccess();
    }

    [Test]
    public async Task ShouldCreateActivity()
    {
        var activityCreateRequest = new ActivityCreateRequest();

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
}
