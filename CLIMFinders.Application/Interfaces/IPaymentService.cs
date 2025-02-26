using CLIMFinders.Application.DTOs;

namespace CLIMFinders.Application.Interfaces
{
    public interface IPaymentService
    {
        GenericResponse AddUpdatePayment(PaymentRequestDto requestDto);
    }
}
