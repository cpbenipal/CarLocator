using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Pages
{
    [Authorize(Roles = "Users")]
    public class SearchModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
