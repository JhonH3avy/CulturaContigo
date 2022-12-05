namespace CulturaContigo.Api.Access.Activities.Contract;

public interface IActivitiesAccess
{
    Task<Activity> CreateActivity(ActivityCreateRequest activityCreateRequest);
    Task<IEnumerable<Activity>> GetActivitiesInDateRange(GetActivitiesInDateRangeRequest getActivitiesInDateRangeRequest);
    Task<Activity> GetActivity(int activityId);
}