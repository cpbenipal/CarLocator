using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Areas.Business.Pages
{
    [Authorize(Roles = "Tow,Impound")]
    public class ManageVehicalsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
