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
        _connectionString = databaseConnectionStringsConfiguration.CulturaContigo ?? string.Empty;
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

    public async Task<IEnumerable<Activity>> GetActivitiesInDateRange(GetActivitiesInDateRangeRequest getActivitiesInDateRangeRequest)
    {
        using var connection = new SqlConnection(_connectionString);
        var parameters = new
        {
            SkippedItems = getActivitiesInDateRangeRequest.PaginationOptions.Size * getActivitiesInDateRangeRequest.PaginationOptions.Page,
            getActivitiesInDateRangeRequest.PaginationOptions.Size,
            StartDate = getActivitiesInDateRangeRequest.StartDateTime,
            EndDate = getActivitiesInDateRangeRequest.EndDateTime
        };
        var result = await connection.QueryAsync<Activity>(@"
            SELECT * 
            FROM Activities 
            WHERE ScheduledDateTime BETWEEN @StartDate AND @EndDate
            ORDER BY ScheduledDateTime ASC 
            OFFSET @SkippedItems ROWS 
            FETCH NEXT @Size ROWS ONLY
        ",
        parameters);
        return result;
    }

    public async Task<Activity> GetActivity(int activityId)
    {
        using var connection = new SqlConnection(_connectionString);
        var result = await connection.QuerySingleAsync<Activity>($"SELECT * FROM Activities WHERE Id = {activityId}");
        return result;
    }
}
