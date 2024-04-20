using AutoMapper;
using MediatR;
using TradeApp.Application.Portfolios.Commands.UpdateBuyPortfolio;
using TradeApp.Domain.Entities;

namespace TradeApp.Application.Portfolios.Queries.GetBuyPortfolioError
{
    public class GetBuyPortfolioErrorQuery : IRequest<GetBuyPortfolioError>
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int Count { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<(PortfolioStock portfolioStock, GetBuyPortfolioErrorQuery input), GetBuyPortfolioError>()
                .ForMember(view =>
                view.StockId,
                opt => opt.MapFrom(src => src.portfolioStock.StockId))
                .ForMember(view =>
                view.StockName,
                opt => opt.MapFrom(src => src.portfolioStock.Stock.Name))
                .ForMember(view =>
                view.PortfolioId,
                opt => opt.MapFrom(src => src.portfolioStock.PortfolioId))
                .ForMember(view =>
                view.ChangeCount,
                opt => opt.MapFrom(src => src.input.Count));
            }
        }

        public GetBuyPortfolioErrorQuery(UpdateBuyPortfolioCommand input)
        {
            Id = input.Id;
            StockId = input.StockId;
            Count = input.Count;
        }
    }
}
