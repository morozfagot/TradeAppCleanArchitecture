using AutoMapper;
using MediatR;
using TradeApp.Application.Portfolios.Commands.UpdateSellPortfolio;

namespace TradeApp.Application.Portfolios.Commands.CheckSellPortfolio
{
    public class CheckSellPortfolioCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int Count { get; set; }

        public CheckSellPortfolioCommand(UpdateSellPortfolioCommand input)
        {
            Id = input.Id;
            StockId = input.StockId;
            Count = input.Count;
        }
    }
}
