using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeApp.Application.Portfolios.Queries.PortfolioById;
using TradeApp.Domain.Entities;

namespace TradeApp.Application.Stocks.Queries.StockById
{
    public class StockByIdSuccess
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Count { get; set; }
        public int TotalPrice { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<PortfolioStock, StockByIdSuccess>()
                .ForMember(svm =>
                svm.Id,
                opt => opt.MapFrom(src => src.StockId))
                .ForMember(svm =>
                svm.Name,
                opt => opt.MapFrom(src => src.Stock.Name))
                .ForMember(svm =>
                svm.Price,
                opt => opt.MapFrom(src => src.Stock.Price));
            }
        }
    }
}
