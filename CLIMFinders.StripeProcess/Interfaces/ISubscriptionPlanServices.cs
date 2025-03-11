using CLIMFinders.Application.DTOs;
using Stripe;

namespace CLIMFinders.StripeProcess.Interfaces
{
    public interface ISubscriptionPlanServices
    {
        string SubscripePlan(SubscriptionRequest plan);
        void SendInvoiceOnSubscriptionSuccess(string sessionId, bool? IsUpdate);
        bool IsSubscriptionActive(string subscriptionId);
        SubscriptionDetail GetSubscriptionById(string subscriptionId);
        Subscription GetSubscriptionByCustomerId(string customerId);
        Subscription GetSubscriptionBySessionId(string sessionId);
        string CreateRenewalCheckoutSession(string sessionId, string priceId);
        bool CancelSubscription(string subscriptionId);
    }
} 