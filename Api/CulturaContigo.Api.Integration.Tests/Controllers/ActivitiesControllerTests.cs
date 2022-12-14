using CulturaContigo.Api.Controllers;

namespace CulturaContigo.Api.Integration.Tests.Controllers;

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
        _sut = _mother.CreateActivitiesController();
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

    [Test]
    public async Task ShouldGetActivitiesNow()
    {
        var activityCreateRequest = _mother.ActivityCreateRequest with
        {
            ScheduledDateTime = DateTime.UtcNow.AddDays(3),
        };
        var expectedActivity1 = await _mother.CreateActivity(activityCreateRequest);
        var expectedActivity2 = await _mother.CreateActivity(activityCreateRequest);
        var expectedActivity3 = await _mother.CreateActivity(activityCreateRequest);
        var expectedActivity4 = await _mother.CreateActivity(activityCreateRequest);
        var paginationOptions = _mother.PaginationOptions;
        var expectedActivitiesIds = new[] {expectedActivity1.Id, expectedActivity2.Id, expectedActivity3.Id, expectedActivity4.Id};

        var actual = await _sut.GetActivitiesNow(paginationOptions);

        Assert.That(actual.Select(x => x.Id), Is.SupersetOf(expectedActivitiesIds));
    }

    [Test]
    public async Task ShouldGetActivitiesComingLate()
    {
        var activityCreateRequest = _mother.ActivityCreateRequest with
        {
            ScheduledDateTime = DateTime.UtcNow.AddDays(15),
        };
        var expectedActivity1 = await _mother.CreateActivity(activityCreateRequest);
        var expectedActivity2 = await _mother.CreateActivity(activityCreateRequest);
        var expectedActivity3 = await _mother.CreateActivity(activityCreateRequest);
        var expectedActivity4 = await _mother.CreateActivity(activityCreateRequest);
        var paginationOptions = _mother.PaginationOptions;
        var expectedActivitiesIds = new[] { expectedActivity1.Id, expectedActivity2.Id, expectedActivity3.Id, expectedActivity4.Id };

        var actual = await _sut.GetActivitiesComingLate(paginationOptions);

        Assert.That(actual.Select(x => x.Id), Is.SupersetOf(expectedActivitiesIds));
    }

    [Test]
    public async Task ShouldGetActivitiesComingSoon()
    {
        var activityCreateRequest = _mother.ActivityCreateRequest with
        {
            ScheduledDateTime = DateTime.UtcNow.AddMonths(3),
        };
        var expectedActivity1 = await _mother.CreateActivity(activityCreateRequest);
        var expectedActivity2 = await _mother.CreateActivity(activityCreateRequest);
        var expectedActivity3 = await _mother.CreateActivity(activityCreateRequest);
        var expectedActivity4 = await _mother.CreateActivity(activityCreateRequest);
        var paginationOptions = _mother.PaginationOptions;
        var expectedActivitiesIds = new[] { expectedActivity1.Id, expectedActivity2.Id, expectedActivity3.Id, expectedActivity4.Id };

        var actual = await _sut.GetActivitiesComingSoon(paginationOptions);

        Assert.That(actual.Select(x => x.Id), Is.SupersetOf(expectedActivitiesIds));
    }
}
