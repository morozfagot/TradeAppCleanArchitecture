using AutoMapper;
using MediatR;
using TradeApp.Application.Portfolios.Commands.UpdateWithdrawPortfolio;

namespace TradeApp.Application.Portfolios.Commands.CheckWithdrawPortfolio
{
    public class CheckWithdrawPortfolioCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public CheckWithdrawPortfolioCommand(UpdateWithdrawPortfolioCommand input)
        {
            Id = input.Id;
            Amount = input.Amount;
        }
    }
}
