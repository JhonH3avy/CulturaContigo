namespace CulturaContigo.Api.Access.Activities.Contract;

public interface IActivitiesAccess
{
    Task<Activity> CreateActivity(ActivityCreateRequest activityCreateRequest);
}