using CLIMFinders.Application.DTOs;
using CLIMFinders.Web.ServiceExtension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Pages
{
    [CustomAuthorize("Users")]
    public class SearchModel : PageModel
    {
        [BindProperty]
        public SearchDto Input { get; set; } = new();
        public void OnGet()
        {
        }
    }
}
