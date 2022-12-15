using CulturaContigo.Api.Controllers.Administration;

namespace CulturaContigo.Api.Integration.Tests.Controllers.Administration;

[TestFixture]
[Category("Integration")]
public class ActivitiesControllerTests
{
    private ActivitiesController _sut;
    private Mother _mother;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mother = new Mother();
    }

    [SetUp]
    public void SetUp()
    {
        _sut = _mother.CreateAdministrationActivitiesController();
    }

    [Test]
    public async Task ShouldPost()
    {
        var activityCreateRequest = _mother.ActivityCreateRequest;

        var actual = await _sut.Post(activityCreateRequest);
        
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
}
