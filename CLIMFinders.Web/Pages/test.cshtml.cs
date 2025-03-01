using Azure.Core;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe.Forwarding;

namespace CLIMFinders.Web.Pages
{ 
    public class TestModel(ILogger<TestModel> logger, IEmailService emailService) : PageModel
    {
        private readonly IEmailService _emailService = emailService;

        private readonly ILogger<TestModel> _logger = logger;

        public IActionResult OnGet()
        {
            return RedirectToPage("/Login");
            // _emailService.SendEmail("cpbenipal@gmail.com", "Test", "request.Body");
        }
    }
}
