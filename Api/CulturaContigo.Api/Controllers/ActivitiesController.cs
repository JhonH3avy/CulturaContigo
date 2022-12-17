using Microsoft.AspNetCore.Mvc;
using CulturaContigo.Api.Manager.Activities.Contract;
using AutoMapper;

namespace CulturaContigo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IActivitiesManager _activitiesManager;

    public ActivitiesController(IMapper mapper, IActivitiesManager activitiesManager)
    {
        _mapper = mapper;
        _activitiesManager = activitiesManager;
    }

    [HttpGet("now")]
    public async Task<IEnumerable<Models.Activity>> GetActivitiesNow([FromQuery] Models.PaginationOptions paginationOptions)
    {
        var managerPaginationOptions = _mapper.Map<Manager.Activities.Contract.PaginationOptions>(paginationOptions);
        var getActivitiesInDateRateRequest = new GetActivitiesInDateRangeRequest
        {
            PaginationOptions = managerPaginationOptions,
            StartDateTime = DateTime.UtcNow,
            EndDateTime = DateTime.UtcNow.AddDays(7)
        };
        var managerActivities = await _activitiesManager.GetActivitiesByDateRange(getActivitiesInDateRateRequest);
        var result = _mapper.Map<IEnumerable<Models.Activity>>(managerActivities);
        return result;
    }

    [HttpGet("soon")]
    public async Task<IEnumerable<Models.Activity>> GetActivitiesComingSoon([FromQuery] Models.PaginationOptions paginationOptions)
    {
        var managerPaginationOptions = _mapper.Map<Manager.Activities.Contract.PaginationOptions>(paginationOptions);
        var getActivitiesInDateRateRequest = new GetActivitiesInDateRangeRequest
        {
            PaginationOptions = managerPaginationOptions,
            StartDateTime = DateTime.UtcNow.AddMonths(1),
            EndDateTime = DateTime.UtcNow.AddYears(1)
        };
        var managerActivities = await _activitiesManager.GetActivitiesByDateRange(getActivitiesInDateRateRequest);
        var result = _mapper.Map<IEnumerable<Models.Activity>>(managerActivities);
        return result;
    }

    [HttpGet("late")]
    public async Task<IEnumerable<Models.Activity>> GetActivitiesComingLate([FromQuery] Models.PaginationOptions paginationOptions)
    {
        var managerPaginationOptions = _mapper.Map<Manager.Activities.Contract.PaginationOptions>(paginationOptions);
        var getActivitiesInDateRateRequest = new GetActivitiesInDateRangeRequest
        {
            PaginationOptions = managerPaginationOptions,
            StartDateTime = DateTime.UtcNow.AddDays(7),
            EndDateTime = DateTime.UtcNow.AddMonths(1)
        };
        var managerActivities = await _activitiesManager.GetActivitiesByDateRange(getActivitiesInDateRateRequest);
        var result = _mapper.Map<IEnumerable<Models.Activity>>(managerActivities);
        return result;
    }

    [HttpGet("{activityId}")]
    public async Task<Models.Activity> Get(int activityId)
    {
        var managerActivity = await _activitiesManager.GetActivity(activityId);
        var result = _mapper.Map<Models.Activity>(managerActivity);
        return result;
    }
}
