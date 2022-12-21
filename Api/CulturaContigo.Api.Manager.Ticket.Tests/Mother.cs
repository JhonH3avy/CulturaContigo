namespace CulturaContigo.Api.Manager.Ticket.Tests;

internal class Mother
{
    public Contract.TicketCreateRequest ManagerTicketCreateRequest => new()
    {
        PersonalId = "personalId",
        TypeOfId = "cc"
    };

    public Access.Ticket.Contract.TicketCreateRequest AccessTicketCreateRequest => new()
    {
        PersonalId = "personalId",
        TypeOfId = "cc"
    };

    public Access.Ticket.Contract.Ticket AccessTicket => new() 
    { 
        PersonalId = "personalId", 
        TypeOfId = "cc" 
    };

    public Contract.Ticket ManagerTicket => new()
    {
        PersonalId = "personalId",
        TypeOfId = "cc"
    };
}