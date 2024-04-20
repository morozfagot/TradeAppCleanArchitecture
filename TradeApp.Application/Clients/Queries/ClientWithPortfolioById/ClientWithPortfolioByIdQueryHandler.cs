using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Clients.Queries.ClientWithPortfolioById
{
    internal class ClientWithPortfolioByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<ClientWithPortfolioByIdQuery, ClientWithPortfolioByIdSuccess>
    {
        public async Task<ClientWithPortfolioByIdSuccess> Handle(ClientWithPortfolioByIdQuery request,
            CancellationToken cancellationToken = default)
        {
            var client = await repositoryManager.ClientRepository.GetClientWithPortfolioByIdAsync(request.Id, cancellationToken);
            var result = mapper.Map<ClientWithPortfolioByIdSuccess>(client);

            return result;
        }
    }
}
