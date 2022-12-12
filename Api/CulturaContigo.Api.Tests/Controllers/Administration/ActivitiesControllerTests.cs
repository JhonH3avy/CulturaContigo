using CulturaContigo.Api.Controllers.Administration;

namespace CulturaContigo.Api.Tests.Controllers.Administration;

[TestFixture]
public class ActivitiesControllerTests
{
    private ActivitiesController _sut;
    private MockRepository _mockRepository;

    [SetUp]
    public void SetUp()
    {
        _sut = new ActivitiesController();
    }
}
