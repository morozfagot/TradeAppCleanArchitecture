using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Portfolios.Commands.CheckSellPortfolio
{
    internal class CheckSellPortfolioCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<CheckSellPortfolioCommand, bool>
    {
        public async Task<bool> Handle(CheckSellPortfolioCommand request,
            CancellationToken cancellationToken = default)
        {
            var portfolio = await repositoryManager.PortfolioRepository.GetPortfolioByIdAsync(request.Id, cancellationToken);
            var portfolioStock = portfolio.PortfolioStocks.Single(ps => ps.StockId == request.StockId);

            if (portfolioStock.Count >= request.Count)
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
