using AutoMapper; 
using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Domain.Entities;
using CLIMFinders.Domain.Entities;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class RegisterService(IUnitOfWork unitOfWork, IHashManager hashManager, IMapper mapper, IUserService userService) : IRegisterService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IHashManager _hashManager = hashManager;
        private readonly IMapper _mapper = mapper;
        private readonly IUserService _userService = userService;

        public ResponseDto CreateUser(BusinessCreditDto dto)
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
                    string password = dto.NewPassword; 
                    var Salt = _hashManager.GenerateSalt();
                    var hashedPassword = _hashManager.HashPassword(dto.NewPassword, Salt);
                    var mappedRequest = new User()
                    {
                        Email = dto.Email,
                        FullName = dto.Name,
                        RoleId = dto.RoleId,
                        ConfirmedOn = DateTime.Now,
                        IsConfirmed = true,
                        IsDeleted = false,
                        PasswordHash = hashedPassword,
                        PasswordSalt = Salt, 
                    };
                    var login = unitOfWork.GetRepository<User>();
                    var repository = unitOfWork.GetRepository<Businesses>();

                    var newuser = login.Insert(mappedRequest);
                    login.Save();
                    Businesses businesses = new()
                    {
                        UserId = newuser.Id,
                        AddedById = newuser.Id,
                        ModifiedById = newuser.Id,
                        AddedOn = DateTime.Now,
                        Address = dto.Address,
                        City = dto.City,
                        ContactPerson = dto.ContactPerson,
                        Description = dto.Description,
                        Id = dto.Id,
                        IsDeleted = false,
                        ModifiedOn = DateTime.Now,
                        Phone = dto.Phone,
                        State = dto.State,
                        ZipCode = dto.ZipCode
                    };
                    repository.Insert(businesses);
                    repository.Save();
                    response.Status = "Business account register successfully";
                    response.Name = dto.Name;
                    response.Id = newuser.Id;
                    response.Email = dto.Email;
                    response.RoleId = dto.RoleId;
                }
            }
            catch
            {
                response.Status = "An unexpected error occurred";
                throw;
            }
            return response;
        }

        public BusinessDto GetMyProfile()
        {
            var userid = _userService.GetUserId();
            var repository = unitOfWork.GetRepository<User>();
            var entity = repository.GetByInclude(u => u.Id == userid, u => u.Businesses);
            BusinessDto business = new();

            business = _mapper.Map<BusinessDto>(entity);

            return business;
        }
        private bool IsUserExists(string email, int Id = 0)
        {
            var repository = unitOfWork.GetRepository<User>();
            return repository != null && repository.GetAll().Any(x => (Id == 0 || x.Id != Id) && x.Email == email);
        }
        public ResponseDto UpdateBusiness(BusinessDto business)
        {
            var response = new ResponseDto();

            try
            {
                if (IsUserExists(business.Email, business.UserId))
                {
                    response.Id = -1;
                    response.Status = "Email already exists";
                }
                else
                {
                    var repository = unitOfWork.GetRepository<User>();
                    var entity = repository.GetById(business.UserId);
                    entity.Email = business.Email;
                    entity.FullName = business.Name;
                    entity.ModifiedById = business.UserId;
                    entity.ModifiedOn = DateTime.Now;
                    repository.Update(entity);
                    repository.Save();

                    var bizrepository = unitOfWork.GetRepository<Businesses>();
                    var businesssDetail = bizrepository.GetById(business.Id);
                    var mapbusiness = _mapper.Map(business, businesssDetail);
                    mapbusiness.ModifiedById = business.UserId;
                    mapbusiness.ModifiedOn = DateTime.Now;
                    bizrepository.Update(mapbusiness);
                    bizrepository.Save();

                    response.Id = 1;
                    response.Status = "Business information updated successfully";
                }
            }
            catch
            {
                response.Status = "An unexpected error occurred";
                throw;
            }
            return response;
        }     
    }
}
