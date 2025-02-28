using CLIMFinders.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Pages
{
    public class ActivateAccountModel(IRegisterService registerService) : PageModel
    {
        private readonly IRegisterService _registerService = registerService;

        [BindProperty(SupportsGet = true)]
        public string code { get; set; }
        public void OnGet()
        {
            if (!string.IsNullOrEmpty(code))
            {
                if (_registerService.ActivateAccount(code))
                {

                }
            }
        }
    }
}
