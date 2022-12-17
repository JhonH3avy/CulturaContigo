using CulturaContigo.Api.Access.Ticket.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace CulturaContigo.Api.Access.Ticket;

public static class ServiceInjection
{
    public static void AddTicketAccessServices(this IServiceCollection services)
    {
        services.AddTransient<ITicketAccess, TicketAccess>();
    }
}
