using AutoMapper;

namespace CulturaContigo.Api.Manager.Ticket;

public static partial class ServiceInjection
{
    public static void AddTicketManagerMappingProfile(this IMapperConfigurationExpression configurationExpression)
    {
        configurationExpression.AddProfile<Mapping.MappingProfile>();
    }
}
