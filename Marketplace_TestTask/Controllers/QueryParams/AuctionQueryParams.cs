using Contracts;
using Contracts.AuctionQueryParams;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.WebAPI.Controllers.QueryParams
{
    public class AuctionQueryParams
    {
        public MarketStatus? Status { get; set; }
        public string? Seller { get; set; }
        public SortKey? SortKey { get; set; }
        public SortOrder? SortOrder { get; set; }

        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;

        [Range(1, int.MaxValue)]
        public int PageSize { get; set; } = 10;
    }
}
