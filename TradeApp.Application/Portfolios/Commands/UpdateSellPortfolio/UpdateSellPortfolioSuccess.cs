namespace TradeApp.Application.Portfolios.Commands.UpdateSellPortfolio
{
    public class UpdateSellPortfolioSuccess
    {
        public int PortfolioId { get; set; }
        public int StockId { get; set; }
        public string StockName { get; set; } = string.Empty;
        public int Count { get; set; }
        public int TotalPrice { get; set; }
        public int ChangeCount { get; set; }
        public int Cash { get; set; }
    }
}
