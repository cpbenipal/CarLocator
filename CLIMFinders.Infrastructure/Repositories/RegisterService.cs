using AutoMapper;
using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Domain.Entities;
using Given.DataContext.Entities;
using System.Security.Cryptography;
using System.Text;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class RegisterService : IRegisterService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHashManager _hashManager;
        private readonly IMapper _mapper;

        public RegisterService(IUnitOfWork unitOfWork, IHashManager hashManager, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _hashManager = hashManager;
            _mapper = mapper;
        }
        public ResponseDto CreateUser(RegisterDto dto)
        {
            var response = new ResponseDto();
            try
            {
                
                if (IsUserExists(dto.Email))
                {
                    response.Id = -1;
                    response.Status = "Email already exists";
                }
                else
                {
                    var login = unitOfWork.GetRepository<User>();
                    var repository = unitOfWork.GetRepository<Businesses>();
                    string password = "0000";
                    var hashed = _hashManager.HashWithSalt(password);
                    var mappedRequest = new User()
                    {
                        Email = dto.Email,
                        FullName = dto.Name,
                        RoleId = dto.FacilityId,
                        ConfirmedOn = DateTime.Now,
                        IsConfirmed = true,
                        IsDeleted = false,
                        PasswordHash = hashed[0],
                        PasswordSalt = hashed[1],
                        Password = _hashManager.EncryptPlainText(password)
                    };
                    var newuser = login.Insert(mappedRequest);
                    login.Save();
                    var mappedbiz = _mapper.Map<Businesses>(dto);
                    mappedbiz.UserId = newuser.Id;
                    mappedbiz.AddedById = newuser.Id;
                    mappedbiz.ModifiedById = newuser.Id; 
                    repository.Insert(mappedbiz);
                    repository.Save();
                    response.Status = "Business account register successfully";
                    response.Name = dto.Name;
                    response.Id = newuser.Id;
                    response.Email = dto.Email; 
                    response.RoleId = dto.FacilityId;
                }
            }
            catch
            {
                response.Status = "An unexpected error occurred";
                throw;
            }
            return response;
        }

        private bool IsUserExists(string email)
        {
            var repository = unitOfWork.GetRepository<User>();
            return repository != null && repository.GetAll().Any(x => x.Email == email);
        }
    }
}
