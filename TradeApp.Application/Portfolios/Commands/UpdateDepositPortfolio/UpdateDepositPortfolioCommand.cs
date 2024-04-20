using AutoMapper;
using MediatR;
using TradeApp.Domain.Entities;

namespace TradeApp.Application.Portfolios.Commands.UpdateDepositPortfolio
{
    public class UpdateDepositPortfolioCommand : IRequest<UpdateDepositPortfolioSuccess>
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<(Portfolio portfolio, UpdateDepositPortfolioCommand input), UpdateDepositPortfolioSuccess>()
                .ForMember(view =>
                view.Id,
                opt => opt.MapFrom(src => src.portfolio.Id))
                .ForMember(view =>
                view.Cash,
                opt => opt.MapFrom(src => src.portfolio.Cash))
                .ForMember(view =>
                view.CashChange,
                opt => opt.MapFrom(src => src.input.Amount));
            }
        }
    }
}
