using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Portfolios.Commands.CheckWithdrawPortfolio
{
    internal class CheckWithdrawPortfolioCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<CheckWithdrawPortfolioCommand, bool>
    {
        public async Task<bool> Handle(CheckWithdrawPortfolioCommand request,
            CancellationToken cancellationToken = default)
        {
            var portfolio = await repositoryManager.PortfolioRepository.GetPortfolioByIdAsync(request.Id, cancellationToken);

            if (portfolio.Cash >= request.Amount)
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
