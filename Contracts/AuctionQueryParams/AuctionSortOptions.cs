using System.Text.Json.Serialization;

namespace Contracts.AuctionQueryParams
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortKey
    {
        Price,
        CreatedDt
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortOrder
    {
        Asc,
        Desc
    }

    public class AuctionSortOptions
    {
        public SortKey SortKey { get; set; }
        public SortOrder SortOrder { get; set; }
    }
}
