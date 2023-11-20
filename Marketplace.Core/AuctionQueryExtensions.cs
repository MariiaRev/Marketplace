using Contracts;
using Contracts.AuctionQueryParams;

namespace Marketplace.Core
{
    public static class AuctionQueryExtensions
    {
        public static IQueryable<Auction> FilterByStatus(this IQueryable<Auction> query, MarketStatus? statusFilter)
        {
            if (statusFilter != null)
            {
                var status = statusFilter.Value;
                return query.Where(a => a.Status == status);
            }
            else return query;
        }
        
        public static IQueryable<Auction> FilterBySeller(this IQueryable<Auction> query, string? sellerFilter)
        {
            if (sellerFilter != null)
            {
                var seller = sellerFilter.ToLower();
                return query.Where(a => a.Seller != null && a.Seller.ToLower().Contains(seller));
            }
            else return query;
        }

        public static IQueryable<Auction> Sort (this IQueryable<Auction> query, AuctionSortOptions? sort)
        {
            if (sort != null)
            {
                return (sort.SortKey, sort.SortOrder) switch
                {
                    (SortKey.Price, SortOrder.Asc) => query.OrderBy(a => a.Price),
                    (SortKey.Price, SortOrder.Desc) => query.OrderByDescending(a => a.Price),
                    (SortKey.CreatedDt, SortOrder.Asc) => query.OrderBy(a => a.CreatedDt),
                    (SortKey.CreatedDt, SortOrder.Desc) => query.OrderByDescending(a => a.CreatedDt),
                    _ => query,
                };
            }
            else return query;
        }

        public static IQueryable<Auction> AddPaging(this IQueryable<Auction> query, Paging paging)
        {
            if (paging != null)
            {
                var toSkipCount = (paging.Page - 1) * paging.PageSize;
                return query.Skip(toSkipCount).Take(paging.PageSize);
            }
            else return query;
        }
    }
}
