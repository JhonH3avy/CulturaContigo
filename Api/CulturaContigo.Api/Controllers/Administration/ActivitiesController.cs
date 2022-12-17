using AutoMapper;
using CulturaContigo.Api.Manager.Activities.Administration.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CulturaContigo.Api.Controllers.Administration;

[Route("api/administration/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private IMapper _mapper;
    private IActivitiesManager _activitiesManager;

    public ActivitiesController(IMapper mapper, IActivitiesManager activitiesManager)
    {
        _mapper = mapper;
        _activitiesManager = activitiesManager;
    }

    internal async Task<Models.Activity> Post(Models.Administration.ActivityCreateRequest activityCreateRequest)
    {
        var managerActivityCreateRequest = _mapper.Map<Manager.Activities.Administration.Contract.ActivityCreateRequest>(activityCreateRequest);
        var managerActivity = await _activitiesManager.CreateActivity(managerActivityCreateRequest);
        var result = _mapper.Map<Models.Activity>(managerActivity);
        return result;
    }
}
