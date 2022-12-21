using AutoMapper;
using CulturaContigo.Api.Controllers.Administration;
using CulturaContigo.Api.Manager.Activities.Administration.Contract;

namespace CulturaContigo.Api.Tests.Controllers.Administration;

[TestFixture]
public class ActivitiesControllerTests
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
        _sut = new ActivitiesController(_mapper.Object, _activitiesManager.Object);
    }

    [Test]
    public async Task ShouldPost()
    {
        var activityCreateRequest = _mother.AdministrationModelActivityCreateRequest;
        var managerActivityCreateRequest = _mother.AdministrationManagerActivityCreateRequest;
        var managerActivity = _mother.AdministrationManagerActivity;
        var expectedActivity = _mother.AdministrationModelActivity with { Id = 1 };

        _mapper
            .Setup(x => x.Map<ActivityCreateRequest>(activityCreateRequest))
            .Returns(managerActivityCreateRequest);
        _activitiesManager
            .Setup(x => x.CreateActivity(managerActivityCreateRequest))
            .ReturnsAsync(managerActivity);
        _mapper
            .Setup(x => x.Map<Models.Administration.Activity>(managerActivity))
            .Returns(expectedActivity);

        var actual = await _sut.Post(activityCreateRequest);

        Assert.That(actual, Is.EqualTo(expectedActivity));

        _mockRepository.VerifyAll();
    }
}
