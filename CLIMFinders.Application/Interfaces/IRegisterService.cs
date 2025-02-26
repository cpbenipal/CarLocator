using CLIMFinders.Application.DTOs;

namespace CLIMFinders.Application.Interfaces
{
    public interface IRegisterService
    {
        ResponseDto CreateUser(BusinessCreditDto dto);
        AddressDto GetMyProfile();
        ResponseDto UpdateBusiness(AddressDto dto);
    }
}
