using CLIMFinders.Application.DTOs;

namespace CLIMFinders.StripeProcess.Interfaces
{
    public interface ISubscriptionPlanServices
    {
        string SubscripePlan(SubscriptionRequest plan);
        void SendInvoiceOnSubscriptionSuccess(string sessionId); 
    }
} 