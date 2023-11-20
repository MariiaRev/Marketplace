namespace Contracts
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Metadata { get; set; }
        public Auction? Auction { get; set; }
    }
}