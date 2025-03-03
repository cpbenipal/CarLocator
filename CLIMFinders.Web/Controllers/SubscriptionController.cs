using CLIMFinders.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Application.Enums;
using CLIMFinders.StripeProcess.Interfaces;

namespace CLIMFinders.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPlanController(ISubscriptionPlanServices services) : ControllerBase
    {
        private readonly ISubscriptionPlanServices _services = services; 
         
        [HttpPost("PostSubscription")]
        public async Task<IActionResult> Subscriptionqweqw([FromBody] SubscriptionRequest plan)
        {
            string sessionUrl = _services.SubscripePlan(plan);            
            // Return the session URL for the redirect
            return new JsonResult(new { sessionUrl });
        }
    }
}