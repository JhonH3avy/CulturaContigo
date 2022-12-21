namespace CulturaContigo.Api.Tests.Controllers.Administration;

internal class Mother
{
    public Models.Administration.ActivityCreateRequest AdministrationModelActivityCreateRequest => new() { };

    public Manager.Activities.Administration.Contract.ActivityCreateRequest AdministrationManagerActivityCreateRequest => new()
    {
        Details = "details",
        Name = "name",
    };

    public Manager.Activities.Administration.Contract.Activity AdministrationManagerActivity => new() 
    {
        Details = "details",
        Name = "name",
    };

    public Models.Administration.Activity AdministrationModelActivity => new()
    {
        Details = "details",
        Name = "name",
    };
}