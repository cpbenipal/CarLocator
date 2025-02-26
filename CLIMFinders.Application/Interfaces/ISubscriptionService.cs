using CLIMFinders.Application.DTOs;

namespace CLIMFinders.Application.Interfaces
{
    public interface ISubscriptionService
    {
        List<SubscriptionPlansDto> GetSubscriptionPlans();
        GenericResponse AddUpdateSubscription(SubscriptionDto requestDto);
    }
}
