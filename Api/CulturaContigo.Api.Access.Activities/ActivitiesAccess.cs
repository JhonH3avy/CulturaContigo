using CulturaContigo.Api.Access.Activities.Contract;
using CulturaContigo.Api.Access.Common;
using Dapper;
using System.Data.SqlClient;

namespace CulturaContigo.Api.Access.Activities;

internal class ActivitiesAccess : IActivitiesAccess
{
    private readonly string _connectionString;

    public ActivitiesAccess(DatabaseConnectionStringsConfiguration databaseConnectionStringsConfiguration)
    {
        _connectionString = databaseConnectionStringsConfiguration.CulturaContigo;
    }

    public async Task<Activity> CreateActivity(ActivityCreateRequest activityCreateRequest)
    {
        using var connection = new SqlConnection(_connectionString);
        var parameters = new DynamicParameters(activityCreateRequest);
        var result = await connection.QuerySingleAsync<Activity>(@"
            DECLARE @ActivitiesIds TABLE (Id INT)
            DECLARE @ActivityId INT

            INSERT INTO Activities(Name, Details, ScheduledDateTime, Place, TicketPrice, Capacity, Available, ImageUrl)
            OUTPUT INSERTED.Id INTO @ActivitiesIds
            VALUES (@Name, @Details, @ScheduledDateTime, @Place, @TicketPrice, @Capacity, @Capacity, @ImageUrl)

            SET @ActivityId = (SELECT TOP 1 Id FROM @ActivitiesIds)

            SELECT * FROM Activities WHERE Id = @ActivityId
        ",
        parameters);
        return result;
    }
}
