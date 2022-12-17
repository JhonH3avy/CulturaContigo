namespace CulturaContigo.Api.Manager.Activities.Administration.Contract;

public interface IActivitiesManager
{
    Task<Activity> CreateActivity(ActivityCreateRequest activityCreateRequest);
}