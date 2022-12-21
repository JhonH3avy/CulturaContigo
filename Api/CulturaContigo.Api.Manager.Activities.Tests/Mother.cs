namespace CulturaContigo.Api.Manager.Activities.Tests;

internal class Mother
{
    public Access.Activities.Contract.Activity AccessActivity => new()
    {
        Name = "name",
        Details = "details"
    };

    public Contract.Activity ManagerActivity => new() 
    {
        Name = "name",
        Details = "details"
    };

    public Contract.GetActivitiesInDateRangeRequest ManagerGetActivitiesInDateRangeRequest => new() 
    {
        PaginationOptions = new Contract.PaginationOptions()
    };

    public Access.Activities.Contract.GetActivitiesInDateRangeRequest AccessGetActivitiesInDateRangeRequest => new() 
    {
        PaginationOptions = new Access.Activities.Contract.PaginationOptions()
    };
}
