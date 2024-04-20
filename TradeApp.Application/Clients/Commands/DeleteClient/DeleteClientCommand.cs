using MediatR;

namespace TradeApp.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<DeleteClientSuccess>
    {
        public int Id { get; set; }
    }
}
