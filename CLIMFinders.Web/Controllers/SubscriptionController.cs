using CLIMFinders.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using Microsoft.AspNetCore.Authorization;

namespace CLIMFinders.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPlanController(IConfiguration configuration, IStripeClient _stripeClient, IHttpContextAccessor httpContextAccessor) : ControllerBase
    { 
        private readonly IConfiguration _configuration = configuration;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IStripeClient stripeClient = _stripeClient;

        [HttpGet("a")] 
        public async Task<IActionResult> GSubscription()
        {
            return new JsonResult(new { sessionUrl = "session.Url" });
        }
        [HttpPost("PostSubscription")]
        public IActionResult Subscriptionqweqw([FromBody] SubscriptionRequest plan)
        { 
            var UrlSchema = _httpContextAccessor.HttpContext?.Request.Scheme;
            var UrlHost = _httpContextAccessor.HttpContext?.Request.Host;

            // Get the corresponding Price ID from appsettings.json
            string? priceId = plan.Plan.ToLower() switch
            {
                "business" => _configuration["Stripe:BusinessPriceId"],
                "user" => _configuration["Stripe:UserPriceId"],
                _ => null
            };

            var domain = $"{Request.Scheme}://{Request.Host}";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems =
                [
                    new() {
                        Price = priceId,
                        Quantity = 1
                    }
                ],
                Mode = "subscription",
                SuccessUrl = $"{domain}/Register?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{domain}/Subscription"
            };

            var sessionService = new SessionService(stripeClient);
            var session = sessionService.Create(options);
            Console.WriteLine("Stripe session object: " + Newtonsoft.Json.JsonConvert.SerializeObject(session));

            // Return the session URL for the redirect
            return new JsonResult(new { sessionUrl = session.Url });
        }
    }
}