using Contracts;
using Contracts.AuctionQueryParams;

namespace Marketplace.Core
{
    public interface IAuctionService
    {
        public Task<PagedData<Auction>> GetAsync(AuctionFilters filters, AuctionSortOptions? sortOptions, Paging pagingOptions, CancellationToken cancellationToken = default);
        public Task<Auction?> GetByIdAsync(int Id, CancellationToken cancellationToken = default);
    }
}