using CLIMFinders.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Application.Enums;

namespace CLIMFinders.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPlanController(ISubscriptionService service, IRegisterService registerService, IConfiguration configuration,
        IStaticSelectOptionService staticSelectOptionService, IStripeClient _stripeClient, ISubscriptionService _subscriptionService, IPaymentService paymentService) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly ISubscriptionService _service = service;
        private readonly IRegisterService registerService = registerService;
        private readonly IStaticSelectOptionService _staticSelectOptionService = staticSelectOptionService;
        private readonly IStripeClient stripeClient = _stripeClient;
        private readonly ISubscriptionService subscriptionService = _subscriptionService;
        private readonly IPaymentService _paymentService = paymentService;


        [HttpPost("PostSubscription")]
        public IActionResult Subscriptionqweqw([FromBody] SubscriptionRequest plan)
        {  
            StripeConfiguration.ApiKey = stripeClient.ApiKey;
             
            // Get the corresponding Price ID from appsettings.json
            string? priceId = plan.Plan.ToLower() switch
            {
                "user" => _configuration["Stripe:UserPriceId"],
                "business" => _configuration["Stripe:BusinessPriceId"],
                _ => null
            };

            var domain = $"{Request.Scheme}://{Request.Host}"; 

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = ["card"],
                LineItems =
                [
                    new() {
                        Price = priceId,
                        Quantity = 1
                    }
                ],
                Mode = "subscription",                
                CustomerEmail = plan.Email, 
                SuccessUrl = $"{domain}/SubscriptionSuccess?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{domain}/SubscriptionCancel"
            }; 
            var sessionService = new SessionService(stripeClient);
            var session = sessionService.Create(options);
            var newUser = new PersonInfoDto()
            {
                Email = plan.Email,
                Name = plan.Name
            };
            registerService.CreateUser(newUser, plan.Plan.Equals("user", StringComparison.CurrentCultureIgnoreCase) ? (int)RoleEnum.Users: 2);
            // Return the session URL for the redirect
            return new JsonResult(new { sessionUrl = session.Url });
        }
    }
}