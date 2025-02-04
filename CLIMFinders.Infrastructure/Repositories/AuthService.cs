using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using Given.DataContext.Entities;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class AuthService: IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHashManager _hashManager;

        public AuthService(IUnitOfWork unitOfWork, IHashManager hashManager)
        {
            this.unitOfWork = unitOfWork;
            _hashManager = hashManager;
        }
        public bool LoginLoginUser(LoginDto loginDto)
        {
            try
            {
                var login = unitOfWork.GetRepository<User>();
                var encryptedText = _hashManager.EncryptPlainText(loginDto.Password);

                var IsSuccess = login.GetAll().FirstOrDefault(e => e.Email == loginDto.Email && e.Password == encryptedText && e.IsDeleted == false && e.IsConfirmed == true);
                
            }
            catch(Exception x) {
                            
            }
            return true;
        }
    }
}
