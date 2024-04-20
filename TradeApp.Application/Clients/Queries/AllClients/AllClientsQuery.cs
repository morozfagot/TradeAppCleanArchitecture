using MediatR;

namespace TradeApp.Application.Clients.Queries.AllClients
{
    public class AllClientsQuery : IRequest<IEnumerable<ClientSuccess>>
    {
    }
}
