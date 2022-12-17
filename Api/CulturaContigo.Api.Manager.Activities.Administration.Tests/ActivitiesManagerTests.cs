using AutoMapper;
using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Manager.Activities.Administration.Contract;

namespace CulturaContigo.Api.Manager.Activities.Administration.Tests;

[TestFixture]
public class ActivitiesManagerTests
{
    private IActivitiesManager _sut;
    private MockRepository _mockRepository;
    private Mock<IMapper> _mapper;
    private Mock<IActivitiesAccess> _activitiesAccess;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new MockRepository(MockBehavior.Strict);
        _mapper = _mockRepository.Create<IMapper>();
        _activitiesAccess = _mockRepository.Create<IActivitiesAccess>();
        _sut = new ActivitiesManager(_mapper.Object, _activitiesAccess.Object);
    }

    [Test]
    public async Task ShouldCreateActivity()
    {
        var activityCreateRequest = new Contract.ActivityCreateRequest();
        var accessActivityCreateRequest = new Access.Activities.Contract.ActivityCreateRequest();
        var accessActivity = new Access.Activities.Contract.Activity();
        var expectedActivity = new Contract.Activity { Id = 1 };

        _mapper
            .Setup(x => x.Map<Access.Activities.Contract.ActivityCreateRequest>(activityCreateRequest))
            .Returns(accessActivityCreateRequest);
        _activitiesAccess
            .Setup(x => x.CreateActivity(accessActivityCreateRequest))
            .ReturnsAsync(accessActivity);
        _mapper
            .Setup(x => x.Map<Contract.Activity>(accessActivity))
            .Returns(expectedActivity);

        var actual = await _sut.CreateActivity(activityCreateRequest);

        Assert.That(actual, Is.EqualTo(expectedActivity));

        _mockRepository.VerifyAll();
    }
}
