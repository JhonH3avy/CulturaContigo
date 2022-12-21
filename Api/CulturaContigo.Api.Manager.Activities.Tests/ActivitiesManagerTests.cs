using AutoMapper;
using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Manager.Activities.Contract;

namespace CulturaContigo.Api.Manager.Activities.Tests;

[TestFixture]
public class ActivitiesManagerTests
{
    private IActivitiesManager _sut;
    private MockRepository _mockRepository;
    private Mock<IMapper> _mapper;
    private Mock<IActivitiesAccess> _activitiesAccess;
    private Mother _mother;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mother = new Mother();
    }

    [SetUp]
    public void Setup()
    {
        _mockRepository = new MockRepository(MockBehavior.Strict);
        _mapper = _mockRepository.Create<IMapper>();
        _activitiesAccess= _mockRepository.Create<IActivitiesAccess>();
        _sut = new ActivitiesManager(_mapper.Object, _activitiesAccess.Object);
    }

    [Test]
    public async Task ShouldGetActivity()
    {
        const int activityId = 1;

        var accessActivity = _mother.AccessActivity;
        var expectedActivity = _mother.ManagerActivity with { Id = activityId };

        _activitiesAccess
            .Setup(x => x.GetActivity(activityId))
            .ReturnsAsync(accessActivity);
        _mapper
            .Setup(x => x.Map<Manager.Activities.Contract.Activity>(accessActivity))
            .Returns(expectedActivity);

        var actual = await _sut.GetActivity(activityId);

        Assert.That(actual, Is.EqualTo(expectedActivity));

        _mockRepository.VerifyAll();
    }

    [Test]
    public async Task ShouldGetActivitiesInDateRange()
    {
        var accessActivities = new[] { _mother.AccessActivity };
        var expectedActivities = new[] { _mother.ManagerActivity with { Id = 1 } };
        var getActivitiesInDateRangeRequest = _mother.ManagerGetActivitiesInDateRangeRequest;
        var accessGetAcvtivitiesInDateRangeRequest = _mother.AccessGetActivitiesInDateRangeRequest;

        _mapper
            .Setup(x => x.Map<Access.Activities.Contract.GetActivitiesInDateRangeRequest>(getActivitiesInDateRangeRequest))
            .Returns(accessGetAcvtivitiesInDateRangeRequest);
        _activitiesAccess
            .Setup(x => x.GetActivitiesInDateRange(accessGetAcvtivitiesInDateRangeRequest))
            .ReturnsAsync(accessActivities);
        _mapper
            .Setup(x => x.Map<IEnumerable<Manager.Activities.Contract.Activity>>(accessActivities))
            .Returns(expectedActivities);

        var actual = await _sut.GetActivitiesByDateRange(getActivitiesInDateRangeRequest);

        Assert.That(actual, Is.EqualTo(expectedActivities));

        _mockRepository.VerifyAll();
    }
}