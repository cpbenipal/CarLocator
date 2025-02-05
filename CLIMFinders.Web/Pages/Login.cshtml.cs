using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Enums;
using CLIMFinders.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IAuthService authService;

        public LoginModel(IAuthService authService)
        {
            this.authService = authService;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = authService.UserLogin(Input);

            if (result!=null)
            {
                if(result.RoleId == (int)RoleEnum.SuperAdmin)
                {
                    return RedirectToPage("/Dashboard", new { area = "Admin" });
                }
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
        [BindProperty]
        public LoginDto Input { get; set; }
    }
}
