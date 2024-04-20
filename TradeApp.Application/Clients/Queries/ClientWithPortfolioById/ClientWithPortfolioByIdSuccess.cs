using AutoMapper;
using TradeApp.Application.Portfolios.Queries.PortfolioById;
using TradeApp.Domain.Entities;

namespace TradeApp.Application.Clients.Queries.ClientWithPortfolioById
{
    public class ClientWithPortfolioByIdSuccess
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public PortfolioByIdSuccess Portfolio { get; set; } = null;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Client, ClientWithPortfolioByIdSuccess>();
            }
        }
    }
}
