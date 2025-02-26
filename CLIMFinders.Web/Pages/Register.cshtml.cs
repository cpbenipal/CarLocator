using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLIMFinders.Web.Pages
{ 
    public class RegisterModel(IRegisterService registerService, IStaticSelectOptionService staticSelectOptionService) : PageModel
    {
        private readonly IRegisterService registerService = registerService; 
        private readonly IStaticSelectOptionService _staticSelectOptionService = staticSelectOptionService;
        public List<SelectListItem> Roles { get; set; }

        public void OnGet()
        {
            Roles = _staticSelectOptionService.RoleOptions();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            { 
                Roles = _staticSelectOptionService.RoleOptions();
                return Page();
            }
            
            var result = registerService.CreateUser(Input); 

            if (result == null || result.Id <= 0)
            {
                Roles = _staticSelectOptionService.RoleOptions();
                ModelState.AddModelError(string.Empty, result?.Status ?? "User registration failed.");
                return Page();
            } 

            return RedirectToPage("/Login");
        }

        [BindProperty]
        public BusinessCreditDto Input { get; set; } 
    }
}
