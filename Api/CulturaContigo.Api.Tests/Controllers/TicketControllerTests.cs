using AutoMapper;
using CulturaContigo.Api.Controllers;
using CulturaContigo.Api.Manager.Ticket.Contract;

namespace CulturaContigo.Api.Tests.Controllers;

[TestFixture]
public class TicketControllerTests
{
    private TicketController _sut;
    private MockRepository _mockRepository;
    private Mock<IMapper> _mapper;
    private Mock<ITicketManager> _ticketManager;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new MockRepository(MockBehavior.Strict);
        _mapper = _mockRepository.Create<IMapper>();
        _ticketManager = _mockRepository.Create<ITicketManager>();
        _sut = new TicketController(_mapper.Object, _ticketManager.Object);
    }

    [Test]
    public async Task ShouldPost()
    {
        var ticketCreateRequest = new Models.TicketCreateRequest();
        var managerTicketCreateRequest = new Manager.Ticket.Contract.TicketCreateRequest();
        var managerTicket = new Manager.Ticket.Contract.Ticket();
        var expectedTicket = new Models.Ticket { Id = 1 };

        _mapper
            .Setup(x => x.Map<Manager.Ticket.Contract.TicketCreateRequest>(ticketCreateRequest))
            .Returns(managerTicketCreateRequest);
        _ticketManager
            .Setup(x => x.CreateTicket(managerTicketCreateRequest))
            .ReturnsAsync(managerTicket);
        _mapper
            .Setup(x => x.Map<Models.Ticket>(managerTicket))
            .Returns(expectedTicket);

        var actual = await _sut.Post(ticketCreateRequest);

        Assert.That(actual, Is.EqualTo(expectedTicket));

        _mockRepository.VerifyAll();
    }
}
