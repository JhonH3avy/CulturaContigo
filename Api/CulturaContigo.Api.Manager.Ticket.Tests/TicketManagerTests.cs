using AutoMapper;
using CulturaContigo.Api.Access.Ticket.Contract;
using CulturaContigo.Api.Manager.Ticket.Contract;

namespace CulturaContigo.Api.Manager.Ticket.Tests;

[TestFixture]
public class TicketManagerTests
{
    private ITicketManager _sut;
    private MockRepository _mockRepository;
    private Mock<IMapper> _mapper;
    private Mock<ITicketAccess> _ticketAccess;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new MockRepository(MockBehavior.Strict);
        _mapper = _mockRepository.Create<IMapper>();
        _ticketAccess = _mockRepository.Create<ITicketAccess>();
        _sut = new TicketManager(_mapper.Object, _ticketAccess.Object);
    }

    [Test]
    public async Task ShouldCreateTicket()
    {
        var ticketCreateRequest = new Contract.TicketCreateRequest();
        var accessTicketCreateRequest = new Access.Ticket.Contract.TicketCreateRequest();
        var accessTicket = new Access.Ticket.Contract.Ticket();
        var expectedTicket = new Contract.Ticket();

        _mapper
            .Setup(x => x.Map<Access.Ticket.Contract.TicketCreateRequest>(ticketCreateRequest))
            .Returns(accessTicketCreateRequest);
        _ticketAccess
            .Setup(x => x.CreateTicket(accessTicketCreateRequest))
            .ReturnsAsync(accessTicket);
        _mapper
            .Setup(x => x.Map<Contract.Ticket>(accessTicket))
            .Returns(expectedTicket);

        var actual = await _sut.CreateTicket(ticketCreateRequest);

        _mockRepository.VerifyAll();
    }
}
