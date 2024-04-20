using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Portfolios.Commands.UpdateWithdrawPortfolio
{
    internal class UpdateWithdrawPortfolioCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<UpdateWithdrawPortfolioCommand, UpdateWithdrawPortfolioSuccess>
    {
        public async Task<UpdateWithdrawPortfolioSuccess> Handle(UpdateWithdrawPortfolioCommand request,
          CancellationToken cancellationToken = default)
        {
            var portfolio = await repositoryManager.PortfolioRepository.GetPortfolioByIdAsync(request.Id, cancellationToken);

            portfolio.Cash -= request.Amount;

            repositoryManager.PortfolioRepository.UpdatePortfolio(portfolio);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<UpdateWithdrawPortfolioSuccess>((portfolio, request));

            return result;
        }
    }
}
