using AutoMapper;
using MediatR;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Application.Clients.Commands.DeleteClient
{
    internal class DeleteClientCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<DeleteClientCommand, DeleteClientSuccess>
    {
        public async Task<DeleteClientSuccess> Handle(DeleteClientCommand request,
            CancellationToken cancellationToken = default)
        {
            var client = await repositoryManager.ClientRepository.GetClientByIdAsync(request.Id, cancellationToken);

            repositoryManager.ClientRepository.DeleteClient(client);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<DeleteClientSuccess>(client);

            return result;
        }
    }
}
