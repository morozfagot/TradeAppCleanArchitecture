using AutoMapper;
using MediatR;
using TradeApp.Domain.Entities;

namespace TradeApp.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<CreateClientSuccess>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int PortfolioCash { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<CreateClientCommand, Client>()
                    .ForPath(c =>
                    c.Portfolio.Cash,
                    opt => opt.MapFrom(src => src.PortfolioCash));
            }
        }
    }
}
