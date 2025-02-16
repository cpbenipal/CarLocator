using AutoMapper;
using Azure;
using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Domain.Entities;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class AuthService(IUnitOfWork unitOfWork, IHashManager hashManager, IMapper mapper, IUserService userService) : IAuthService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IHashManager _hashManager = hashManager;
        private readonly IUserService _userService = userService;
        private readonly IMapper _mapper = mapper;

        public LoginResponseDto UserLogin(LoginDto loginDto)
        {
            var response = new LoginResponseDto();
            try
            {
                var repository = unitOfWork.GetRepository<User>();
                var entity = repository.GetAllInclude(navigationProperties: u => u.Businesses).FirstOrDefault(e => e.Email == loginDto.Email && e.IsDeleted == false && e.IsConfirmed == true);

                if (entity == null || !_hashManager.VerifyPassword(loginDto.Password, entity.PasswordHash, entity.PasswordSalt))
                {
                    response.Id = 0;
                    response.UIMessage = "Invalid username or password.";
                }
                else
                {
                    response = _mapper.Map<LoginResponseDto>(entity);
                }
                return response;
            }
            catch
            {
                response.Id = -1;
                response.UIMessage = "An error has been occurred on Login Attempt. Try after sometime.";
                throw;
            }
        }
        public ResponseDto ChangePassword(ChangePasswordDto dto)
        {
            var response = new ResponseDto();
            try
            {
                var repository = unitOfWork.GetRepository<User>();
                var entity = repository.GetById(_userService.GetUserId());

                if (entity == null || !_hashManager.VerifyPassword(dto.OldPassword, entity.PasswordHash, entity.PasswordSalt))
                {
                    response.Id = -1;
                    response.Status = "Current password is incorrect.";
                }
                else
                { 
                    var newSalt = _hashManager.GenerateSalt();
                    entity.PasswordHash = _hashManager.HashPassword(dto.NewPassword, newSalt);
                    entity.PasswordSalt = newSalt;
                    entity.ModifiedById = entity.Id;
                    entity.ModifiedOn = DateTime.Now;
                    repository.Update(entity);
                    repository.Save();
                    response.Id = entity.Id;
                    response.RoleId = entity.RoleId;
                    response.Email = entity.Email;
                    response.Name = entity.FullName;
                    response.Status = "Your password has been changed successfully.";
                }
            }
            catch
            {
                response.Id = -1;
                response.Status = "An unexpected error occurred";
                throw;
            }
            return response;
        }
    }
}
