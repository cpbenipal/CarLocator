using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLIMFinders.Web.Pages
{ 
    public class RegisterModel(IRegisterService registerService, IJwtTokenService jwtTokenService, IStaticSelectOptionService staticSelectOptionService) : PageModel
    {
        private readonly IRegisterService registerService = registerService;
        private readonly IJwtTokenService _jwtTokenService = jwtTokenService;
        private readonly IStaticSelectOptionService _staticSelectOptionService = staticSelectOptionService;
        public List<SelectListItem> Roles { get; set; }

        public void OnGet()
        {
            Roles = _staticSelectOptionService.RoleOptions();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                                   .SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)
                                   .ToList();
                Roles = _staticSelectOptionService.RoleOptions();
                return Page();
            }
            
            var result = registerService.CreateUser(Input); 

            if (result == null || result.Id <= 0)
            {
                Roles = _staticSelectOptionService.RoleOptions();
                ModelState.AddModelError(string.Empty, result?.Status ?? "User registration failed.");
                return Page();
            }

            //// Generate JWT token
            //var (token, expiration) = _jwtTokenService.GenerateToken(new LoginResponseDto
            //{
            //    Email = result.Email,
            //    FullName = result.Name,
            //    RoleId = result.RoleId
            //});

            //// Set token in HttpOnly cookie with expiration
            //Response.Cookies.Append("AuthToken", token, new CookieOptions
            //{
            //    HttpOnly = true,
            //    Secure = true,  // Ensures token is only sent over HTTPS
            //    SameSite = SameSiteMode.Strict,
            //    Expires = expiration  // Sync cookie expiration with token expiration
            //});

            return RedirectToPage("/Login");
        }

        [BindProperty]
        public BusinessCreditDto Input { get; set; } 
    }
}
