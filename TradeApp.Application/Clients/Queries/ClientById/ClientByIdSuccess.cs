using AutoMapper;
using TradeApp.Domain.Entities;

namespace TradeApp.Application.Clients.Queries.ClientById
{
    public class ClientByIdSuccess
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Client, ClientByIdSuccess>();
            }
        }
    }
}
