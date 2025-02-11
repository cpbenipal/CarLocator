using CLIMFinders.Application.DTOs;

namespace CLIMFinders.Application.Interfaces
{
    public interface IRegisterService
    {
        ResponseDto CreateUser(RegisterDto dto);
    }
}
