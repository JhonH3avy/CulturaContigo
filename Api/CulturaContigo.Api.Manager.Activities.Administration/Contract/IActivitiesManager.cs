namespace CulturaContigo.Api.Manager.Activities.Administration.Contract;

public interface IActivitiesManager
{
    Task<Activity> CreateActivity(ActivityCreateRequest activityCreateRequest);
    Task<IEnumerable<Activity>> GetActivitiesAfterDate(DateTime startDate, PaginationOptions paginationOptions);
    Task<IEnumerable<Activity>> GetActivitiesBeforeDate(DateTime startDate, PaginationOptions paginationOptions);
}