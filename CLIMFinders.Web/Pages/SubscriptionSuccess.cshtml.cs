using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Pages
{
    public class SubscriptionSuccessModel() : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Session_Id { get; set; }

        public void OnGet()
        {  

        }
    }
}
