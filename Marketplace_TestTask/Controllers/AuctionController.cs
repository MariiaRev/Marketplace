using Contracts;
using Contracts.AuctionQueryParams;
using Marketplace.Core;
using Marketplace.WebAPI.Controllers.QueryParams;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _service;

        public AuctionController (IAuctionService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAuctions([FromQuery] AuctionQueryParams auctionQueryParams)
        {
            try
            {
                var filters = BuildFilters(auctionQueryParams);
                var sortOptions = BuildSortOptions(auctionQueryParams);
                var paging = BuildPagingOptions(auctionQueryParams);

                var result = await _service.GetAsync(filters, sortOptions, paging);        
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAuctionById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                if (result is null)
                    return NotFound($"No auction with Id: {id}");
                else return Ok(result);
            }
            catch 
            { 
                return BadRequest(); 
            }
        }

        private static AuctionFilters BuildFilters(AuctionQueryParams auctionQueryParams)
        {
            return new() 
            { 
                Seller = auctionQueryParams.Seller,
                Status = auctionQueryParams.Status 
            };
        }

        private static AuctionSortOptions? BuildSortOptions(AuctionQueryParams auctionQueryParams)
        {
            var sortKey = auctionQueryParams.SortKey;
            if (sortKey is not null)
            {
                SortOrder sortOrder =
                    auctionQueryParams.SortOrder is null
                    ? SortOrder.Asc
                    : auctionQueryParams.SortOrder.Value;              // if the sort order is not set, then it is "Asc" by default

                return new AuctionSortOptions()
                {
                    SortKey = sortKey.Value,
                    SortOrder = sortOrder
                };
            }
            else return null;
        }
        
        private static Paging BuildPagingOptions(AuctionQueryParams auctionQueryParams)
        {
            return new Paging() 
            { 
                Page = auctionQueryParams.Page, 
                PageSize = auctionQueryParams.PageSize 
            };
        }
    }
}