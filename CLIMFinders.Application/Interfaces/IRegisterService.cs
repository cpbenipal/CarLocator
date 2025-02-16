using CLIMFinders.Application.DTOs;

namespace CLIMFinders.Application.Interfaces
{
    public interface IRegisterService
    {
        ResponseDto CreateUser(BusinessCreditDto dto);
        BusinessDto GetMyProfile();
        ResponseDto UpdateBusiness(BusinessDto dto);
    }
}
