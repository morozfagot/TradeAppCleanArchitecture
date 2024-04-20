using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Portfolios.Commands.UpdateSellPortfolio
{
    internal class UpdateSellPortfolioCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<UpdateSellPortfolioCommand, UpdateSellPortfolioSuccess>
    {
        public async Task<UpdateSellPortfolioSuccess> Handle(UpdateSellPortfolioCommand request,
           CancellationToken cancellationToken = default)
        {
            var portfolio = await repositoryManager.PortfolioRepository.GetPortfolioByIdAsync(request.Id, cancellationToken);
            var portfolioStock = portfolio.PortfolioStocks.Single(ps => ps.StockId == request.StockId);

            portfolioStock.Count -= request.Count;
            portfolioStock.TotalPrice = portfolioStock.Count * portfolioStock.Stock.Price;
            portfolio.Cash += request.Count * portfolioStock.Stock.Price;

            repositoryManager.PortfolioRepository.UpdatePortfolio(portfolio);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<UpdateSellPortfolioSuccess>((portfolioStock, request));

            return result;
        }
    }
}
