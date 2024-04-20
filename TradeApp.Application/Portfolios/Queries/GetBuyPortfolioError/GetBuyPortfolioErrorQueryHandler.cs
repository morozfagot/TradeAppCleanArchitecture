using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Portfolios.Queries.GetBuyPortfolioError
{
    internal class GetBuyPortfolioErrorQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<GetBuyPortfolioErrorQuery, GetBuyPortfolioError>
    {
        public async Task<GetBuyPortfolioError> Handle(GetBuyPortfolioErrorQuery request,
            CancellationToken cancellationToken = default)
        {
            var portfolio = await repositoryManager.PortfolioRepository.GetPortfolioByIdAsync(request.Id, cancellationToken);
            var portfolioStock = portfolio.PortfolioStocks.Single(ps => ps.StockId == request.StockId);
            var result = mapper.Map<GetBuyPortfolioError>((portfolioStock, request));

            return result;
        }
    }
}
