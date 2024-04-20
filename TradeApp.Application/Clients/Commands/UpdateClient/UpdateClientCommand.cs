using AutoMapper;
using MediatR;
using TradeApp.Domain.Entities;

namespace TradeApp.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<UpdateClientSuccess>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<UpdateClientCommand, Client>();
            }
        }
    }
}
