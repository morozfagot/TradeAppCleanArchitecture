using AutoMapper;
using TradeApp.Domain.Entities;

namespace TradeApp.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientSuccess
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Client, DeleteClientSuccess>();
            }
        }
    }
}
