using CLIMFinders.StripeProcess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Pages
{
    public class SubscriptionSuccessModel(ISubscriptionPlanServices services) : PageModel
    {
        private readonly ISubscriptionPlanServices _services = services;

        [BindProperty(SupportsGet = true)]
        public string Session_Id { get; set; }

        public void OnGet()
        {
            _services.SendInvoiceOnSubscriptionSuccess(Session_Id);
        } 
    }
}
