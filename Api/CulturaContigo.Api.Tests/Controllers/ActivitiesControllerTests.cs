using AutoMapper;
using CulturaContigo.Api.Controllers;
using CulturaContigo.Api.Manager.Activities.Contract;

namespace CulturaContigo.Api.Tests.Controllers;

[TestFixture]
internal class ActivitiesControllerTests
{
    private ActivitiesController _sut;
    private MockRepository _mockRepository;
    private Mock<IActivitiesManager> _activitiesManager;
    private Mock<IMapper> _mapper;
    private Mother _mother;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mother = new Mother();
    }

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new MockRepository(MockBehavior.Strict);
        _mapper = _mockRepository.Create<IMapper>();
        _activitiesManager = _mockRepository.Create<IActivitiesManager>();
;        _sut = new ActivitiesController(_mapper.Object, _activitiesManager.Object);
    }

    [Test]
    public async Task ShouldGet()
    {
        const int activityId = 1;
        var managerActivity = _mother.ManagerActivity;
        var expectedActivity = _mother.ModelActivity with { Id = activityId };

        _activitiesManager
            .Setup(x => x.GetActivity(activityId))
            .ReturnsAsync(managerActivity);
        _mapper
            .Setup(x => x.Map<Models.Activity>(managerActivity))
            .Returns(expectedActivity);

        var actual = await _sut.Get(activityId);

        Assert.That(actual, Is.EqualTo(expectedActivity));

        _mockRepository.VerifyAll();
    }

    [Test]
    public async Task ShouldGetActivitiesNow()
    {
        var startDateTime = DateTime.UtcNow;
        var endDateTime = DateTime.UtcNow.AddDays(7);
        var paginationOptions = new Models.PaginationOptions();
        var managerPaginationOptions = new PaginationOptions();
        var managerActivities = new[] { _mother.ManagerActivity with { Id = 1 } };
        var expectedActivities = new[] { _mother.ModelActivity with { Id = 1 } };

        _mapper
            .Setup(x => x.Map<Manager.Activities.Contract.PaginationOptions>(paginationOptions))
            .Returns(() => managerPaginationOptions);
        _activitiesManager
            .Setup(x => x.GetActivitiesByDateRange(It.Is<GetActivitiesInDateRangeRequest>(request => 
            request.PaginationOptions == managerPaginationOptions &&
            (request.StartDateTime - startDateTime).Duration().Seconds < 1 &&
            (request.EndDateTime - endDateTime).Duration().Seconds < 1)))
            .ReturnsAsync(managerActivities);
        _mapper
            .Setup(x => x.Map<IEnumerable<Models.Activity>>(managerActivities))
            .Returns(expectedActivities);

        var actual = await _sut.GetActivitiesNow(paginationOptions);

        Assert.That(actual, Is.EqualTo(expectedActivities));

        _mockRepository.VerifyAll();
    }

    [Test]
    public async Task ShouldGetActivitiesComingLate()
    {
        var startDateTime = DateTime.UtcNow.AddDays(7);
        var endDateTime = DateTime.UtcNow.AddMonths(1);
        var paginationOptions = new Models.PaginationOptions();
        var managerPaginationOptions = new PaginationOptions();
        var managerActivities = new[] { _mother.ManagerActivity with { Id = 1 } };
        var expectedActivities = new[] { _mother.ModelActivity with { Id = 1 } };

        _mapper
            .Setup(x => x.Map<Manager.Activities.Contract.PaginationOptions>(paginationOptions))
            .Returns(() => managerPaginationOptions);
        _activitiesManager
            .Setup(x => x.GetActivitiesByDateRange(It.Is<GetActivitiesInDateRangeRequest>(request =>
            request.PaginationOptions == managerPaginationOptions &&
            (request.StartDateTime - startDateTime).Duration().Seconds < 1 &&
            (request.EndDateTime - endDateTime).Duration().Seconds < 1)))
            .ReturnsAsync(managerActivities);
        _mapper
            .Setup(x => x.Map<IEnumerable<Models.Activity>>(managerActivities))
            .Returns(expectedActivities);

        var actual = await _sut.GetActivitiesComingLate(paginationOptions);

        Assert.That(actual, Is.EqualTo(expectedActivities));

        _mockRepository.VerifyAll();
    }

    [Test]
    public async Task ShouldGetActivitiesComingSoon()
    {
        var startDateTime = DateTime.UtcNow.AddMonths(1);
        var endDateTime = DateTime.UtcNow.AddYears(1);
        var paginationOptions = new Models.PaginationOptions();
        var managerPaginationOptions = new PaginationOptions();
        var managerActivities = new[] { _mother.ManagerActivity with { Id = 1 } };
        var expectedActivities = new[] { _mother.ModelActivity with { Id = 1 } };

        _mapper
            .Setup(x => x.Map<Manager.Activities.Contract.PaginationOptions>(paginationOptions))
            .Returns(() => managerPaginationOptions);
        _activitiesManager
            .Setup(x => x.GetActivitiesByDateRange(It.Is<GetActivitiesInDateRangeRequest>(request =>
            request.PaginationOptions == managerPaginationOptions &&
            (request.StartDateTime - startDateTime).Duration().Seconds < 1 &&
            (request.EndDateTime - endDateTime).Duration().Seconds < 1)))
            .ReturnsAsync(managerActivities);
        _mapper
            .Setup(x => x.Map<IEnumerable<Models.Activity>>(managerActivities))
            .Returns(expectedActivities);

        var actual = await _sut.GetActivitiesComingSoon(paginationOptions);

        Assert.That(actual, Is.EqualTo(expectedActivities));

        _mockRepository.VerifyAll();
    }
}
