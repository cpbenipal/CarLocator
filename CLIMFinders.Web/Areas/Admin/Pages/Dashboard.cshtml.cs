using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Areas.Admin.Pages
{
    [Authorize(Roles = "SuperAdmin")]
    public class DashboardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
