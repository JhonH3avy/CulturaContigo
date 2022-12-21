namespace CulturaContigo.Api.Tests.Controllers;

internal class Mother
{
    public Manager.Activities.Contract.Activity ManagerActivity => new()
    {
        Details = "details",
        Name = "name",
    };

    public Models.Activity ModelActivity => new()
    {
        Details = "details",
        Name = "name",
    };

    public Manager.Ticket.Contract.TicketCreateRequest ManagerTicketCreateRequest => new()
    {
        PersonalId = "personalId",
        TypeOfId = "cc",
    };

    public Manager.Ticket.Contract.Ticket ManagerTicket => new() 
    {
        PersonalId = "personalId",
        TypeOfId = "cc",
    };

    public Models.Ticket ModelTicket => new()
    {
        PersonalId = "personalId",
        TypeOfId = "cc",
    };
}