using AutoMapper;
using MediatR;
using TradeApp.Application.Portfolios.Commands.UpdateBuyPortfolio;

namespace TradeApp.Application.Portfolios.Commands.CheckBuyPortfolio
{
    public class CheckBuyPortfolioCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int Count { get; set; }


        public CheckBuyPortfolioCommand(UpdateBuyPortfolioCommand input)
        {
            Id = input.Id;
            StockId = input.StockId;
            Count = input.Count;
        }
    }
}
