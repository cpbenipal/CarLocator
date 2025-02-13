using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Enums;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Pages
{
    [AllowAnonymous]
    public class LoginModel(IJwtTokenService jwtTokenService, IAuthService authService) : PageModel
    {
        private readonly IAuthService authService = authService;
        private readonly IJwtTokenService _jwtTokenService = jwtTokenService;

        public void OnGet()
        { 
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            } 

            var result = authService.UserLogin(Input);

            if (result != null)
            {
                var token = _jwtTokenService.GenerateToken(result);
                 
                result.Token = token;
                Response.Cookies.Append("AuthToken", token, new CookieOptions { HttpOnly = true, Secure = true, Expires = DateTime.UtcNow.AddHours(2) });
                return result.RoleId switch
                {
                    (int)RoleEnum.SuperAdmin => RedirectToPage("/Dashboard", new { area = "Admin" }),
                    (int)RoleEnum.Impound or (int)RoleEnum.Tow => RedirectToPage("/ManageVehicals", new { area = "Business" }),
                    _ => RedirectToPage("/Index"),
                };
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
        [BindProperty]
        public LoginDto Input { get; set; }  
    }
}
