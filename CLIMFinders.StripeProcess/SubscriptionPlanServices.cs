using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Enums;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.StripeProcess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;

namespace CLIMFinders.StripeProcess
{
    public class SubscriptionPlanServices(IConfiguration configuration, IStripeClient _stripeClient, IEmailService emailService, IRegisterService registerService) : ISubscriptionPlanServices
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IStripeClient stripeClient = _stripeClient;
        private readonly IRegisterService _registerService = registerService;
        private readonly IEmailService _emailService = emailService;


        public string SubscripePlan(SubscriptionRequest plan)
        {
            if (_registerService.IsUserExists(plan.Email))
            {
                return "N";
            }
            StripeConfiguration.ApiKey = stripeClient.ApiKey;

            var customerService = new CustomerService();

            // Check if customer already exists (to prevent duplicates)
            var customers = customerService.List(new CustomerListOptions { Email = plan.Email });
            string? customerId = customers.Data.Count > 0 ? customers.Data[0].Id : null;
             
            if (customerId == null)
            {
                var customer = customerService.Create(new CustomerCreateOptions
                {
                    Email = plan.Email,
                    Name = plan.Name,
                });
                customerId = customer.Id;
            }
            else {
                customerService.Update(customerId , new CustomerUpdateOptions
                {
                    Email = plan.Email,
                    Name = plan.Name,
                }); 
            }

            // Get the corresponding Price ID from appsettings.json
            string? priceId = plan.Plan.ToLower() switch
            {
                "user" => _configuration["Stripe:UserPriceId"],
                "business" => _configuration["Stripe:BusinessPriceId"],
                _ => null
            };

            var domain = _configuration["JwtSettings:Issuer"];

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                new SessionLineItemOptions
                {Price = priceId,Quantity = 1}
                },
                Mode = "subscription",
                Customer = customerId, 
                CustomerUpdate = new SessionCustomerUpdateOptions
                {
                    Name = "auto"
                },
                SuccessUrl = $"{domain}/SubscriptionSuccess?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{domain}/SubscriptionCancel",
                Metadata = new Dictionary<string, string>
                {
                { "RoleId", plan.Plan.Equals("user", StringComparison.CurrentCultureIgnoreCase) ? "1": "2"  },
                { "SubRoleId", plan.SubRoleId }
                }
            };

            var sessionService = new SessionService(stripeClient);
            var session = sessionService.Create(options);


            return session.Url;
        }
        public void SendInvoiceOnSubscriptionSuccess(string sessionId)
        {

            var sessionService = new SessionService();
            var session = sessionService.Get(sessionId);
            var invoiceService = new InvoiceService();

            // Get the latest invoice for this subscription
            var invoices = invoiceService.List(new InvoiceListOptions
            {
                Subscription = session.SubscriptionId,
                Limit = 1
            });

            if (invoices.Data.Count > 0)
            {
                var invoice = invoices.Data[0]; // Get most recent invoice

                if (invoice.Status == "paid") // Ensure it's already paid
                {
                    Console.WriteLine($"Invoice URL: {invoice.HostedInvoiceUrl}");
                    PersonInfoDto personInfo = new()
                    {
                        Email = invoice.CustomerEmail,
                        Name = invoice.CustomerName
                    };

                    var RoleId = Convert.ToInt32(session.Metadata["RoleId"]);
                    var SubRoleId = Convert.ToInt32(session.Metadata["SubRoleId"]);
                    SubscriptionDto subscription = new()
                    {
                        SessionId = sessionId,
                        SubscriptionId = session.SubscriptionId,
                        TierId = RoleId,
                    };
                    var result = _registerService.CreateUser(personInfo, RoleId, SubRoleId, subscription);

                    //return invoice.HostedInvoiceUrl;
                    _emailService.SendEmail(result.Email, "Your Invoice - Payment Successful", $"<p>Thank you for your payment!</p><p>You can download your invoice here: <a href='{invoice.HostedInvoiceUrl}'>View Invoice</a></p>");
                }
                else
                {
                    throw new Exception("Invoice is not yet paid.");
                }
            }
            else
            {
                throw new Exception("No invoice found for this subscription.");
            }
        }
    }
}
