using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeApp.Application.Clients.Queries.ClientWithPortfolioById;
using TradeApp.Application.Stocks.Queries.StockById;
using TradeApp.Domain.Entities;

namespace TradeApp.Application.Portfolios.Queries.PortfolioById
{
    public class PortfolioByIdSuccess
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public List<StockByIdSuccess>? Stocks { get; set; }
        public int Cash { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Portfolio, PortfolioByIdSuccess>()
                .ForMember(pvm =>
                pvm.Stocks,
                opt => opt.MapFrom(src => src.PortfolioStocks));
            }
        }
    }
}
