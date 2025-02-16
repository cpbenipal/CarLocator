using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Infrastructure.Repositories;
using CLIMFinders.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CLIMFinders.Web.Pages
{
    [Authorize]
    public class MyAccountModel(IRegisterService registerService) : PageModel
    {
        private readonly IRegisterService registerService = registerService;

        [BindProperty]
        public BusinessDto Input { get; set; }

        public void OnGet()
        {
            Input = registerService.GetMyProfile();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                                    .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage)
                                    .ToList();

                return Page();
            }

            var result = registerService.UpdateBusiness(Input);
            ModelState.AddModelError(string.Empty, result?.Status ?? "Business update action failed.");
            return Page();
        }
    }
}