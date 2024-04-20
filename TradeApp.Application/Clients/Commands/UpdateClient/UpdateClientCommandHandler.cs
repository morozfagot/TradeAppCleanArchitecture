using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Clients.Commands.UpdateClient
{
    internal class UpdateClientCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<UpdateClientCommand, UpdateClientSuccess>
    {
        public async Task<UpdateClientSuccess> Handle(UpdateClientCommand request,
            CancellationToken cancellationToken = default)
        {
            var client = await repositoryManager.ClientRepository.GetClientByIdAsync(request.Id, cancellationToken);
            mapper.Map(request, client);

            repositoryManager.ClientRepository.UpdateClient(client);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<UpdateClientSuccess>(client);

            return result;
        }
    }
}
