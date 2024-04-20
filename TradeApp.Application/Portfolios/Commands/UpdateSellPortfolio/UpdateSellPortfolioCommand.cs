using AutoMapper;
using MediatR;
using TradeApp.Domain.Entities;

namespace TradeApp.Application.Portfolios.Commands.UpdateSellPortfolio
{
    public class UpdateSellPortfolioCommand : IRequest<UpdateSellPortfolioSuccess>
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int Count { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<(PortfolioStock portfolioStock, UpdateSellPortfolioCommand input), UpdateSellPortfolioSuccess>()
                .ForMember(view =>
                view.PortfolioId,
                opt => opt.MapFrom(src => src.portfolioStock.PortfolioId))
                .ForMember(view =>
                view.StockId,
                opt => opt.MapFrom(src => src.portfolioStock.StockId))
                .ForMember(view =>
                view.StockName,
                opt => opt.MapFrom(src => src.portfolioStock.Stock.Name))
                .ForMember(view =>
                view.Cash,
                opt => opt.MapFrom(src => src.portfolioStock.Portfolio.Cash))
                .ForMember(view =>
                view.ChangeCount,
                opt => opt.MapFrom(src => src.input.Count))
                .ForMember(view =>
                view.TotalPrice,
                opt => opt.MapFrom(src => src.portfolioStock.TotalPrice))
                .ForMember(view =>
                view.Count,
                opt => opt.MapFrom(src => src.portfolioStock.Count));
            }
        }
    }
}
