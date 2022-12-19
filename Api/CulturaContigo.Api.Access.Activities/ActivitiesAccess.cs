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
        var parameters = new DynamicParameters();
        parameters.Add("Name", activityCreateRequest.Name);
        parameters.Add("Details", activityCreateRequest.Details);
        parameters.Add("ScheduledDateTime", activityCreateRequest.ScheduledDateTime, System.Data.DbType.DateTime2, precision: 7);
        parameters.Add("Place", activityCreateRequest.Place);
        parameters.Add("TicketPrice", activityCreateRequest.TicketPrice);
        parameters.Add("Capacity", activityCreateRequest.Capacity);
        parameters.Add("ImageUrl", activityCreateRequest.ImageUrl);
        using var connection = new SqlConnection(_connectionString);
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
                ImageUrl,
                IsDeleted
            FROM Activities WHERE Id = @ActivityId
        ",
        parameters);
        return result;
    }

    public async Task DeleteActivity(int activityId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("ActivityId", activityId);
        using var connection = new SqlConnection(_connectionString);
        var result = await connection.ExecuteAsync(@"
            UPDATE Activities 
            SET
                IsDeleted = 1
            WHERE Id = @ActivityId
        ",
        parameters);
    }

    public async Task<IEnumerable<Activity>> GetActivitiesAfterDate(DateTime startDate, PaginationOptions paginationOptions)
    {
        var parameters = new DynamicParameters();
        parameters.Add("SkippedItems", paginationOptions.Size * paginationOptions.Page);
        parameters.Add("Size", paginationOptions.Size);
        parameters.Add("StartDate", startDate, System.Data.DbType.DateTime2, precision: 7);
        using var connection = new SqlConnection(_connectionString);
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
                ImageUrl,
                IsDeleted
            FROM Activities 
            WHERE 
                ScheduledDateTime > @StartDate
            AND
                IsDeleted = 0
            ORDER BY ScheduledDateTime ASC 
            OFFSET @SkippedItems ROWS 
            FETCH NEXT @Size ROWS ONLY
        ",
        parameters);
        return result;
    }

    public async Task<IEnumerable<Activity>> GetActivitiesBeforeDate(DateTime startDate, PaginationOptions paginationOptions)
    {
        var parameters = new DynamicParameters();
        parameters.Add("SkippedItems", paginationOptions.Size * paginationOptions.Page);
        parameters.Add("Size", paginationOptions.Size);
        parameters.Add("StartDate", startDate, System.Data.DbType.DateTime2, precision: 7);
        using var connection = new SqlConnection(_connectionString);
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
                ImageUrl,
                IsDeleted
            FROM Activities 
            WHERE 
                ScheduledDateTime < @StartDate
            AND
                IsDeleted = 0
            ORDER BY ScheduledDateTime DESC 
            OFFSET @SkippedItems ROWS 
            FETCH NEXT @Size ROWS ONLY
        ",
        parameters);
        return result;
    }

    public async Task<IEnumerable<Activity>> GetActivitiesInDateRange(GetActivitiesInDateRangeRequest getActivitiesInDateRangeRequest)
    {
        var parameters = new DynamicParameters();
        parameters.Add("SkippedItems", getActivitiesInDateRangeRequest.PaginationOptions.Size * getActivitiesInDateRangeRequest.PaginationOptions.Page);
        parameters.Add("Size", getActivitiesInDateRangeRequest.PaginationOptions.Size);
        parameters.Add("StartDate", getActivitiesInDateRangeRequest.StartDateTime, System.Data.DbType.DateTime2, precision: 7);
        parameters.Add("EndDate", getActivitiesInDateRangeRequest.EndDateTime, System.Data.DbType.DateTime2, precision: 7);
        using var connection = new SqlConnection(_connectionString);
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
                ImageUrl,
                IsDeleted
            FROM Activities 
            WHERE 
                ScheduledDateTime BETWEEN @StartDate AND @EndDate
            AND
                IsDeleted = 0
            ORDER BY ScheduledDateTime ASC 
            OFFSET @SkippedItems ROWS 
            FETCH NEXT @Size ROWS ONLY
        ",
        parameters);
        return result;
    }

    public async Task<Activity> GetActivity(int activityId)
    {
        var parameters = new
        {
            ActivityId = activityId
        };
        using var connection = new SqlConnection(_connectionString);
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
                ImageUrl,
                IsDeleted
            FROM Activities WHERE Id = @ActivityId",
            parameters);
        return result;
    }
}
