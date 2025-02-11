using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Enums;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Application.Services;
using CLIMFinders.Infrastructure.Repositories;
using Given.DataContext.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLIMFinders.Web.Pages
{
    public class RegisterModel(IRegisterService registerService, IJwtTokenService jwtTokenService) : PageModel
    {
        private readonly IRegisterService registerService = registerService;
        private readonly IJwtTokenService _jwtTokenService = jwtTokenService;

        public List<SelectListItem> Roles { get; set; }

        public void OnGet()
        {
            Roles = new List<SelectListItem>
            {
                new SelectListItem { Text = RoleEnum.Tow.ToString(), Value = ((int)RoleEnum.Tow).ToString() },
                new SelectListItem { Text = RoleEnum.Impound.ToString(),Value = ((int)RoleEnum.Impound).ToString() }
            };
        }
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = registerService.CreateUser(Input);
            if (result.Id > 0)
            {
                var token = _jwtTokenService.GenerateToken(new LoginResponseDto() { Email = result.Email, FullName = result.Name, RoleId = result.RoleId });

                Response.Cookies.Append("AuthToken", token, new CookieOptions { HttpOnly = true, Secure = true });
                return RedirectToPage("/Dashboard", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError(string.Empty, result.Status);
            }
            return Page();
        }
        [BindProperty]
        public RegisterDto Input { get; set; }
    }
}
