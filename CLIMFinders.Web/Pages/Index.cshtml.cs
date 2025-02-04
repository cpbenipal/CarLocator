using Azure.Core;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Pages
{
    //[Authorize(Roles = "SuperAdmin")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IJwtTokenService _jwtTokenService;
        public IndexModel(ILogger<IndexModel> logger, IJwtTokenService _jwtTokenService)
        {
            _logger = logger; this._jwtTokenService = _jwtTokenService;
        }

        public void OnGet()
        {
            var token = _jwtTokenService.GenerateToken("1", "SuperAdmin");
        }
    }
}
