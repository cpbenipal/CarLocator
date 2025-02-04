using CLIMFinders.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public LoginDto Input { get; set; }
    }
}
