using AutoMapper;
using CulturaContigo.Api.Controllers;
using CulturaContigo.Api.Manager.Activities.Contract;
using Moq;

namespace CulturaContigo.Api.Tests.Controllers;

[TestFixture]
internal class ActivitiesControllerTests
{
    private ActivitiesController _sut;
    private MockRepository _mockRepository;
    private Mock<IActivitiesManager> _activitiesManager;
    private Mock<IMapper> _mapper;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new MockRepository(MockBehavior.Strict);
        _mapper = _mockRepository.Create<IMapper>();
        _activitiesManager = _mockRepository.Create<IActivitiesManager>();
;        _sut = new ActivitiesController(_mapper.Object, _activitiesManager.Object);
    }

    [Test]
    public async Task ShouldCreateActivity()
    {
        var activityCreateRequest = new Models.ActivityCreateRequest();
        var managerActivityCreateRequest = new Manager.Activities.Contract.ActivityCreateRequest();
        var managerActivity = new Manager.Activities.Contract.Activity();
        var expectedActivity = new Models.Activity { Id = 1 };
       
        _mapper
            .Setup(x => x.Map<Manager.Activities.Contract.ActivityCreateRequest>(activityCreateRequest))
            .Returns(managerActivityCreateRequest);
        _activitiesManager
            .Setup(x => x.CreateActivity(managerActivityCreateRequest))
            .ReturnsAsync(managerActivity);
        _mapper
            .Setup(x => x.Map<Models.Activity>(managerActivity))
            .Returns(expectedActivity);

        var actual = await _sut.Post(activityCreateRequest);

        Assert.That(actual, Is.EqualTo(expectedActivity));

        _mockRepository.VerifyAll();
    }
}
