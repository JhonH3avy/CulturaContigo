namespace CulturaContigo.Api.Manager.Activities.Administration.Tests;

internal class Mother
{
    public Contract.ActivityCreateRequest AdministrationManagerActivityCreateRequest => new () 
    {
        Name = "name",
        Details = "details"
    };

    public Access.Activities.Contract.ActivityCreateRequest AccessActivityCreateRequest => new()
    {
        Name = "name",
        Details = "details"
    };

    public Access.Activities.Contract.Activity AccessActivity => new()
    {
        Name = "name",
        Details = "details"
    };

    public Contract.Activity AdministrationManagerActivity => new()
    {
        Name = "name",
        Details = "details"
    };
}