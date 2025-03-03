using CLIMFinders.Application.Interfaces;
using CLIMFinders.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLIMFinders.Web.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController(ISearchService searchService, ILogger<SearchController> logger) : ControllerBase
    {
        private readonly ISearchService _searchService = searchService;
        private readonly ILogger<SearchController> _logger = logger;

        [HttpGet("searchbyvin")]
        public IActionResult SearchByVin(string vin) 
        {
            var response = _searchService.GetSearchResult(vin);
            return Ok(new { data = response });
        }
    }
}
