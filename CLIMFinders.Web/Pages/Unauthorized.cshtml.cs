using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Pages
{
    [Authorize]
    public class UnauthorizedModel : PageModel
    {
        public void OnGet()
        {
            Response.Cookies.Delete("AuthToken");
        }
    }
}
