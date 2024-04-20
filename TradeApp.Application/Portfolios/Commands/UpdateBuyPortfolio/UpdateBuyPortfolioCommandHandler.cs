using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Portfolios.Commands.UpdateBuyPortfolio
{
    internal class UpdateBuyPortfolioCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<UpdateBuyPortfolioCommand, UpdateBuyPortfolioSuccess>
    {
        public async Task<UpdateBuyPortfolioSuccess> Handle(UpdateBuyPortfolioCommand request,
            CancellationToken cancellationToken = default)
        {
            var portfolio = await repositoryManager.PortfolioRepository.GetPortfolioByIdAsync(request.Id, cancellationToken);
            var portfolioStock = portfolio.PortfolioStocks.Single(ps => ps.StockId == request.StockId);

            portfolioStock.Count += request.Count;
            portfolioStock.TotalPrice = portfolioStock.Count * portfolioStock.Stock.Price;
            portfolio.Cash -= request.Count * portfolioStock.Stock.Price;

            repositoryManager.PortfolioRepository.UpdatePortfolio(portfolio);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<UpdateBuyPortfolioSuccess>((portfolioStock, request));

            return result;
        }
    }
}
