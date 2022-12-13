using CulturaContigo.Api.Access.Common;
using CulturaContigo.Api.Access.Ticket.Contract;
using Dapper;
using System.Data.SqlClient;

namespace CulturaContigo.Api.Access.Ticket;

internal class TicketAccess : ITicketAccess
{
    private DatabaseConnectionStringsConfiguration _databaseConnectionStringsConfiguration;

    public TicketAccess(DatabaseConnectionStringsConfiguration databaseConnectionStringsConfiguration)
    {
        _databaseConnectionStringsConfiguration = databaseConnectionStringsConfiguration;
    }

    public async Task<Contract.Ticket> CreateTicket(TicketCreateRequest ticketCreateRequest)
    {
        var parameters = new DynamicParameters(ticketCreateRequest);
        using var dbConnection = new SqlConnection(_databaseConnectionStringsConfiguration.CulturaContigo);
        var result = await dbConnection.QuerySingleAsync<Contract.Ticket>(@"
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
