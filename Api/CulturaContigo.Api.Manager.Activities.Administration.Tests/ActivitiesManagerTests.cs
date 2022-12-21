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
        _activitiesAccess = _mockRepository.Create<IActivitiesAccess>();
        _sut = new ActivitiesManager(_mapper.Object, _activitiesAccess.Object);
    }

    [Test]
    public async Task ShouldCreateActivity()
    {
        var activityCreateRequest = _mother.AdministrationManagerActivityCreateRequest;
        var accessActivityCreateRequest = _mother.AccessActivityCreateRequest;
        var accessActivity = _mother.AccessActivity;
        var expectedActivity = _mother.AdministrationManagerActivity with { Id = 1 };

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

    [Test]
    public async Task ShouldGetActivitiesAfterDate()
    {
        var startDate = DateTime.UtcNow;
        var accessPaginationOptions = new Access.Activities.Contract.PaginationOptions();
        var paginationOptions = new Contract.PaginationOptions();
        var accessActivities = new[] { _mother.AccessActivity };
        var expectedActivities = new[] { _mother.AdministrationManagerActivity with { Id = 1 } };

        _mapper
            .Setup(x => x.Map<Access.Activities.Contract.PaginationOptions>(paginationOptions))
            .Returns(accessPaginationOptions);
        _activitiesAccess
            .Setup(x => x.GetActivitiesAfterDate(startDate, accessPaginationOptions))
            .ReturnsAsync(accessActivities);
        _mapper
            .Setup(x => x.Map<IEnumerable<Contract.Activity>>(accessActivities))
            .Returns(expectedActivities);

        var actual = await _sut.GetActivitiesAfterDate(startDate, paginationOptions);

        Assert.That(actual, Is.EqualTo(expectedActivities));

        _mockRepository.VerifyAll();
    }

    [Test]
    public async Task ShouldGetActivitiesBeforeDate()
    {
        var startDate = DateTime.UtcNow;
        var accessPaginationOptions = new Access.Activities.Contract.PaginationOptions();
        var paginationOptions = new Contract.PaginationOptions();
        var accessActivities = new[] { _mother.AccessActivity };
        var expectedActivities = new[] { _mother.AdministrationManagerActivity with { Id = 1 } };

        _mapper
            .Setup(x => x.Map<Access.Activities.Contract.PaginationOptions>(paginationOptions))
            .Returns(accessPaginationOptions);
        _activitiesAccess
            .Setup(x => x.GetActivitiesBeforeDate(startDate, accessPaginationOptions))
            .ReturnsAsync(accessActivities);
        _mapper
            .Setup(x => x.Map<IEnumerable<Contract.Activity>>(accessActivities))
            .Returns(expectedActivities);

        var actual = await _sut.GetActivitiesBeforeDate(startDate, paginationOptions);

        Assert.That(actual, Is.EqualTo(expectedActivities));

        _mockRepository.VerifyAll();
    }
}
