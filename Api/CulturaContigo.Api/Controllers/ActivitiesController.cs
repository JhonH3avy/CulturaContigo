using CulturaContigo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;
using CulturaContigo.Api.Manager.Activities.Contract;
using AutoMapper;

namespace CulturaContigo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly string _connectionString;
    private readonly IMapper _mapper;
    private readonly IActivitiesManager _activitiesManager;

    public ActivitiesController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("CulturaContigo.Db") ?? string.Empty;
    }

    public ActivitiesController(IMapper mapper, IActivitiesManager activitiesManager)
    {
        _mapper = mapper;
        _activitiesManager = activitiesManager;
    }

    [HttpGet("now")]
    public async Task<IEnumerable<Models.Activity>> GetActivitiesNow([FromQuery] Models.PaginationOptions paginationOptions)
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
        var result = await connection.QueryAsync<Models.Activity>(@"
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
    public async Task<IEnumerable<Models.Activity>> GetActivitiesComingSoon([FromQuery] Models.PaginationOptions paginationOptions)
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
        var result = await connection.QueryAsync<Models.Activity>(@"
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
    public async Task<IEnumerable<Models.Activity>> GetActivitiesComingLate([FromQuery] Models.PaginationOptions paginationOptions)
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
        var result = await connection.QueryAsync<Models.Activity>(@"
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
    public async Task<Models.Activity> Get(int activityId)
    {
        using var connection = new SqlConnection(_connectionString);
        var result = await connection.QuerySingleAsync<Models.Activity>($"SELECT * FROM Activities WHERE Id = {activityId}");
        return result;
    }

    [HttpPost]
    public async Task<Models.Activity> Post([FromBody] Models.ActivityCreateRequest activityCreateRequest)
    {
        var managerActivityCreateRequest = _mapper.Map<Manager.Activities.Contract.ActivityCreateRequest>(activityCreateRequest);
        var managerActivity = await _activitiesManager.CreateActivity(managerActivityCreateRequest);
        var result = _mapper.Map<Models.Activity>(managerActivity);
        return result;
    }
}
