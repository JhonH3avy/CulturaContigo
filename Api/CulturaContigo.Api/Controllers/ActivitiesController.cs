using CulturaContigo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;

namespace CulturaContigo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly string _connectionString;

    public ActivitiesController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("CulturaContigo.Db") ?? string.Empty;
    }

    [HttpGet("now")]
    public async Task<IEnumerable<Activity>> GetActivitiesNow([FromQuery] PaginationOptions paginationOptions)
    {
        using var connection = new SqlConnection(_connectionString);
        var now = DateTime.UtcNow;
        var aWeekLater = DateTime.UtcNow.AddDays(7);
        var parameters = new
        {
            SkippedItems = paginationOptions.Size * paginationOptions.Page,
            paginationOptions.Size,
            Now = now,
            AWeekLater = aWeekLater
        };
        var result = await connection.QueryAsync<Activity>(@"
            SELECT * 
            FROM Activities 
            WHERE ScheduledDateTime BETWEEN @Now AND @AWeekLater
            ORDER BY ScheduledDateTime ASC 
            OFFSET @SkippedItems ROWS 
            FETCH NEXT @Size ROWS ONLY
        ",
        parameters);
        return result;
    }

    [HttpGet("soon")]
    public async Task<IEnumerable<Activity>> GetActivitiesComingSoon([FromQuery] PaginationOptions paginationOptions)
    {
        using var connection = new SqlConnection(_connectionString);
        var aWeekLater = DateTime.UtcNow.AddDays(7);
        var aMonthLater = DateTime.UtcNow.AddDays(30);
        var parameters = new
        {
            SkippedItems = paginationOptions.Size * paginationOptions.Page,
            paginationOptions.Size,
            AWeekLater = aWeekLater,
            AMonthLater = aMonthLater
        };
        var result = await connection.QueryAsync<Activity>(@"
            SELECT * 
            FROM Activities 
            WHERE ScheduledDateTime BETWEEN @AWeekLater AND @AMonthLater
            ORDER BY ScheduledDateTime ASC 
            OFFSET @SkippedItems ROWS 
            FETCH NEXT @Size ROWS ONLY
        ",
        parameters);
        return result;
    }

    [HttpGet("late")]
    public async Task<IEnumerable<Activity>> GetActivitiesComingLate([FromQuery] PaginationOptions paginationOptions)
    {
        using var connection = new SqlConnection(_connectionString);
        var now = DateTime.UtcNow;
        var aMonthLater = DateTime.UtcNow.AddDays(30);
        var parameters = new
        {
            SkippedItems = paginationOptions.Size * paginationOptions.Page,
            paginationOptions.Size,
            AMonthLater = aMonthLater
        };
        var result = await connection.QueryAsync<Activity>(@"
            SELECT * 
            FROM Activities 
            WHERE ScheduledDateTime > @AMonthLater
            ORDER BY ScheduledDateTime ASC 
            OFFSET @SkippedItems ROWS 
            FETCH NEXT @Size ROWS ONLY
        ",
        parameters);
        return result;
    }

    [HttpGet("{activityId}")]
    public async Task<Activity> Get(int activityId)
    {
        using var connection = new SqlConnection(_connectionString);
        var result = await connection.QuerySingleAsync<Activity>($"SELECT * FROM Activities WHERE Id = {activityId}");
        return result;
    }

    [HttpPost]
    public async Task<Activity> Post([FromBody] ActivityCreateRequest activityCreateRequest)
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
