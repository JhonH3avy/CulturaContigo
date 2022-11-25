using CulturaContigo.Api.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CulturaContigo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly string _connectionString;

    public TicketController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("CulturaContigo.Db") ?? string.Empty;
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<Ticket> Post([FromBody] TicketCreateRequest ticketCreateRequest)
    {
        using var connection = new SqlConnection(_connectionString);
        var parameters = new DynamicParameters(ticketCreateRequest);
        var result = await connection.QuerySingleAsync<Ticket>(@"
            DECLARE @TicketIds TABLE (Id INT)
            DECLARE @TicketId INT

            INSERT INTO Tickets (ActivityId, TypeOfId, PersonalId, NumberOfTickets)
            OUTPUT INSERTED.Id INTO @TicketIds
            VALUES (@ActivityId, @TypeOfId, @PersonalId, @NumberOfTickets)

            UPDATE Activities
            SET
                Available = Available - @NumberOfTickets
            WHERE Id = @ActivityId

            SET @TicketId = (SELECT TOP 1 Id FROM @TicketIds)

            SELECT * FROM Tickets WHERE Id = @TicketId
        ",
        parameters);
        return result;
    }
}
