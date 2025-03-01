using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Pages
{
    public class SubscriptionModel(ISubscribeService service) : PageModel
    {
        private readonly ISubscribeService _service = service;

        public void OnGet()
        {
            Input = _service.GetSubscriptionPlans();
        }
        [BindProperty]
        public List<SubscriptionPlansDto> Input { get; set; } = [];
    }

}
