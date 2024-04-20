namespace TradeApp.Application.Portfolios.Queries.GetBuyPortfolioError
{
    public class GetBuyPortfolioError
    {
        public int PortfolioId { get; set; }
        public int StockId { get; set; }
        public string StockName { get; set; } = string.Empty;
        public int ChangeCount { get; set; }
    }
}
