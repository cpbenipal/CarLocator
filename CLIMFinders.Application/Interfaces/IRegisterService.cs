using CLIMFinders.Application.DTOs;

namespace CLIMFinders.Application.Interfaces
{
    public interface IRegisterService
    {
        ResponseDto CreateUser(PersonInfoDto dto, int RoleID, int? SubRoleId = null , SubscriptionDto? subscription = null);
        AddressDto GetMyProfile();
        ResponseDto UpdateBusiness(AddressDto dto);
        bool IsUserExists(string email, int Id = 0);
        bool ActivateAccount(string code);
    }
}
