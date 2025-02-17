using Stripe;
using Stripe.Checkout;

namespace CLIMFinders.Web.ServiceExtension
{
    public class StripeIntegrationService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
   
        public void ProcessPayment(string plan)
        {
            string secretKey = _configuration["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = secretKey;

            string? priceId = plan.ToLower() switch
            {
                "standard" => _configuration["Stripe:StandardPriceId"],
                "premium" => _configuration["Stripe:PremiumPriceId"],
                _ => null
            };

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                Mode = "subscription",
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Price = priceId,
                    Quantity = 1
                }
            },
                SuccessUrl = $"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host}/Subscription/Success",
                CancelUrl = $"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host}/Subscription/Cancel"
            };

            var service = new SessionService();
            Session session = service.Create(options);
        }
    }
}
