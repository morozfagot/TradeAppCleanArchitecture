using MediatR;

namespace TradeApp.Application.Clients.Queries.ClientById
{
    public class ClientByIdQuery : IRequest<ClientByIdSuccess>
    {
        public int Id { get; set; }
    }
}
