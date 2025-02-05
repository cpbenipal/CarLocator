using AutoMapper;
using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using Given.DataContext.Entities;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHashManager _hashManager;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IHashManager hashManager, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _hashManager = hashManager;
            _mapper = mapper;
        }
        public LoginResponseDto UserLogin(LoginDto loginDto)
        {
            try
            {
                var login = unitOfWork.GetRepository<User>();
                var encryptedText = _hashManager.EncryptPlainText(loginDto.Password);

                var response = login.GetAll().FirstOrDefault(e => e.Email == loginDto.Email && e.Password == encryptedText && e.IsDeleted == false && e.IsConfirmed == true);
                var mapped = _mapper.Map<LoginResponseDto>(response);

                return mapped;
            }
            catch
            {
                throw;
            }
        }
    }
}
