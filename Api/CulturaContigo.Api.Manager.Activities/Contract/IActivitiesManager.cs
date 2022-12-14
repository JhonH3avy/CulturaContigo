namespace CulturaContigo.Api.Manager.Activities.Contract;

public interface IActivitiesManager
{
    Task<IEnumerable<Activity>> GetActivitiesByDateRange(GetActivitiesInDateRangeRequest getActivitiesInDateRangeRequest);
    Task<Activity> GetActivity(int activityId);
}