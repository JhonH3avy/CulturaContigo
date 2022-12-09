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
        var parameters = new DynamicParameters();
        parameters.Add("Name", activityCreateRequest.Name);
        parameters.Add("Details", activityCreateRequest.Details);
        parameters.Add("ScheduledDateTime", activityCreateRequest.ScheduledDateTime, System.Data.DbType.DateTime2, precision: 7);
        parameters.Add("Place", activityCreateRequest.Place);
        parameters.Add("TicketPrice", activityCreateRequest.TicketPrice);
        parameters.Add("Capacity", activityCreateRequest.Capacity);
        parameters.Add("ImageUrl", activityCreateRequest.ImageUrl);
        var result = await connection.QuerySingleAsync<Activity>(@"
            DECLARE @ActivitiesIds TABLE (Id INT)
            DECLARE @ActivityId INT

            INSERT INTO Activities(Name, Details, ScheduledDateTime, Place, TicketPrice, Capacity, Available, ImageUrl)
            OUTPUT INSERTED.Id INTO @ActivitiesIds
            VALUES (@Name, @Details, @ScheduledDateTime, @Place, @TicketPrice, @Capacity, @Capacity, @ImageUrl)

            SET @ActivityId = (SELECT TOP 1 Id FROM @ActivitiesIds)

            SELECT 
                Id,
                Name, 
                Details, 
                ScheduledDateTime, 
                Place, 
                TicketPrice, 
                Capacity, 
                Available, 
                ImageUrl
            FROM Activities WHERE Id = @ActivityId
        ",
        parameters);
        return result;
    }

    public async Task<IEnumerable<Activity>> GetActivitiesInDateRange(GetActivitiesInDateRangeRequest getActivitiesInDateRangeRequest)
    {
        using var connection = new SqlConnection(_connectionString);
        var parameters = new DynamicParameters();
        parameters.Add("SkippedItems", getActivitiesInDateRangeRequest.PaginationOptions.Size * getActivitiesInDateRangeRequest.PaginationOptions.Page);
        parameters.Add("Size", getActivitiesInDateRangeRequest.PaginationOptions.Size);
        parameters.Add("StartDate", getActivitiesInDateRangeRequest.StartDateTime, System.Data.DbType.DateTime2, precision: 7);
        parameters.Add("EndDate", getActivitiesInDateRangeRequest.EndDateTime, System.Data.DbType.DateTime2, precision: 7);
        var result = await connection.QueryAsync<Activity>(@"
            SELECT 
                Id,
                Name, 
                Details, 
                ScheduledDateTime, 
                Place, 
                TicketPrice, 
                Capacity, 
                Available, 
                ImageUrl
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
        var parameters = new
        {
            activityId = activityId
        };
        var result = await connection.QuerySingleAsync<Activity>(@"
            SELECT 
                Id,
                Name, 
                Details, 
                ScheduledDateTime, 
                Place, 
                TicketPrice, 
                Capacity, 
                Available, 
                ImageUrl            
            FROM Activities WHERE Id = @ActivityId",
            parameters);
        return result;
    }
}
