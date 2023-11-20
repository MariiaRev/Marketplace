namespace Contracts
{
    public class Auction
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime FinishedDt { get; set; }
        public decimal Price { get; set; }
        public MarketStatus Status { get; set; } = MarketStatus.None;
        public string? Seller { get; set; }
        public string? Buyer { get; set; }
    }
}
