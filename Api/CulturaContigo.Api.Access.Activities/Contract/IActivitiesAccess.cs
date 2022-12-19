namespace CulturaContigo.Api.Access.Activities.Contract;

public interface IActivitiesAccess
{
    Task<Activity> CreateActivity(ActivityCreateRequest activityCreateRequest);
    Task DeleteActivity(int activityId);
    Task<IEnumerable<Activity>> GetActivitiesAfterDate(DateTime startDate, PaginationOptions paginationOptions);
    Task<IEnumerable<Activity>> GetActivitiesBeforeDate(DateTime startDate, PaginationOptions paginationOptions);
    Task<IEnumerable<Activity>> GetActivitiesInDateRange(GetActivitiesInDateRangeRequest getActivitiesInDateRangeRequest);
    Task<Activity> GetActivity(int activityId);
}