using Contracts;
using Contracts.AuctionQueryParams;
using Marketplace.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Core
{
    public class AuctionService: IAuctionService
    {
        private readonly MarketplaceContext _context = new();

        public async Task<PagedData<Auction>> GetAsync(AuctionFilters filters, AuctionSortOptions? sortOptions, Paging pagingOptions, CancellationToken cancellationToken = default)
        {
            var pagedAuctions = 
                await _context.Auctions
                .FilterBySeller(filters.Seller)
                .FilterByStatus(filters.Status)
                .Sort(sortOptions)
                .AddPaging(pagingOptions)
                .ToListAsync(cancellationToken);

            return new PagedData<Auction>()
            {
                Page = pagingOptions.Page,
                PageSize = pagingOptions.PageSize,
                Value = pagedAuctions
            };
        }

        public async Task<Auction?> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            var auction = await _context.Auctions.Where(a => a.Id == Id).FirstOrDefaultAsync(cancellationToken);
            return auction;
        }

        
    }
}
