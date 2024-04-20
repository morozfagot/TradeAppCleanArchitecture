using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Clients.Queries.ClientById
{
    internal class ClientByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<ClientByIdQuery, ClientByIdSuccess>
    {
        public async Task<ClientByIdSuccess> Handle(ClientByIdQuery request,
            CancellationToken cancellationToken = default)
        {
            var client = await repositoryManager.ClientRepository.GetClientByIdAsync(request.Id, cancellationToken);
            var result = mapper.Map<ClientByIdSuccess>(client);

            return result;
        }
    }
}
