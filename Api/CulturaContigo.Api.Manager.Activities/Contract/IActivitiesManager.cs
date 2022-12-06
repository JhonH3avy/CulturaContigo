namespace CulturaContigo.Api.Manager.Activities.Contract;

public interface IActivitiesManager
{
    Task<Activity> CreateActivity(ActivityCreateRequest activityCreateRequest);
    Task<IEnumerable<Activity>> GetActivitiesByDateRange(GetActivitiesInDateRangeRequest getActivitiesInDateRangeRequest);
    Task<Activity> GetActivity(int activityId);
}