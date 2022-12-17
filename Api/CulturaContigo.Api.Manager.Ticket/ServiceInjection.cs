using CulturaContigo.Api.Manager.Ticket.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace CulturaContigo.Api.Manager.Ticket;

public static partial class ServiceInjection
{
    public static void AddTicketManagerServices(this IServiceCollection services)
    {
        services.AddTransient<ITicketManager, TicketManager>();
    }
}
