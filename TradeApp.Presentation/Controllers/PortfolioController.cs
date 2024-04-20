using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeApp.Application.Clients.Queries.ClientWithPortfolioById;
using TradeApp.Application.Portfolios.Commands.CheckBuyPortfolio;
using TradeApp.Application.Portfolios.Commands.CheckSellPortfolio;
using TradeApp.Application.Portfolios.Commands.CheckWithdrawPortfolio;
using TradeApp.Application.Portfolios.Commands.UpdateBuyPortfolio;
using TradeApp.Application.Portfolios.Commands.UpdateDepositPortfolio;
using TradeApp.Application.Portfolios.Commands.UpdateSellPortfolio;
using TradeApp.Application.Portfolios.Commands.UpdateWithdrawPortfolio;
using TradeApp.Application.Portfolios.Queries.GetBuyPortfolioError;
using TradeApp.Application.Portfolios.Queries.GetSellPortfolioError;

namespace TradeApp.Presentation.Controllers
{
    public class PortfolioController(ISender sender, IMapper mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> List(int id, CancellationToken cancellationToken)
        {
            ViewData["Title"] = "Акции";

            var model = await sender.Send(new ClientWithPortfolioByIdQuery(id), cancellationToken);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(UpdateBuyPortfolioCommand input, CancellationToken cancellationToken)
        {
            if (await sender.Send(new CheckBuyPortfolioCommand(input), cancellationToken))
            {
                var model = await sender.Send(input, cancellationToken);

                return Ok(model);
            }
            else
            {
                var error = await sender.Send(new GetBuyPortfolioErrorQuery(input), cancellationToken);

                return UnprocessableEntity(error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Sell(UpdateSellPortfolioCommand input, CancellationToken cancellationToken)
        {
            if (await sender.Send(new CheckSellPortfolioCommand(input), cancellationToken))
            {
                var model = await sender.Send(input, cancellationToken);

                return Ok(model);
            }
            else
            {
                var error = await sender.Send(new GetSellPortfolioErrorQuery(input), cancellationToken);

                return UnprocessableEntity(error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(UpdateWithdrawPortfolioCommand input, CancellationToken cancellationToken)
        {
            if (await sender.Send(new CheckWithdrawPortfolioCommand(input), cancellationToken))
            {
                var model = await sender.Send(input, cancellationToken);

                return Ok(model);
            }
            else
            {
                return UnprocessableEntity();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(UpdateDepositPortfolioCommand input, CancellationToken cancellationToken)
        {
            var model = sender.Send(input, cancellationToken);

            return Ok(model);
        }
    }
}