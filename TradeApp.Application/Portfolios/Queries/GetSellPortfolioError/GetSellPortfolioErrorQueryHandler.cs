using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Portfolios.Queries.GetSellPortfolioError
{
    internal class GetSellPortfolioErrorQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<GetSellPortfolioErrorQuery, GetSellPortfolioError>
    {
        public async Task<GetSellPortfolioError> Handle(GetSellPortfolioErrorQuery request,
            CancellationToken cancellationToken = default)
        {
            var portfolio = await repositoryManager.PortfolioRepository.GetPortfolioByIdAsync(request.Id, cancellationToken);
            var portfolioStock = portfolio.PortfolioStocks.Single(ps => ps.StockId == request.StockId);
            var result = mapper.Map<GetSellPortfolioError>((portfolioStock, request));

            return result;
        }
    }
}
