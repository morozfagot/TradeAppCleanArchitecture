using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Portfolios.Commands.CheckBuyPortfolio
{
    internal class CheckBuyPortfolioCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<CheckBuyPortfolioCommand, bool>
    {
        public async Task<bool> Handle(CheckBuyPortfolioCommand request,
            CancellationToken cancellationToken = default)
        {
            var portfolio = await repositoryManager.PortfolioRepository.GetPortfolioByIdAsync(request.Id, cancellationToken);
            var portfolioStock = portfolio.PortfolioStocks.Single(ps => ps.StockId == request.StockId);

            if (portfolio.Cash >= request.Count * portfolioStock.Stock.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
