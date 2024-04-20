using MediatR;

namespace TradeApp.Application.Clients.Queries.ClientWithPortfolioById
{
    public class ClientWithPortfolioByIdQuery : IRequest<ClientWithPortfolioByIdSuccess>
    {
        public int Id { get; set; }

        public ClientWithPortfolioByIdQuery(int id) => Id = id;
    }
}
