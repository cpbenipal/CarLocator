using AutoMapper;
using Azure;
using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class SearchService(IVehicleService vehicleService, IUserService userService, IUnitOfWork unitOfWork,
        IEmailService emailService, IConfiguration config, IWebHostEnvironment env, IStaticSelectOptionService staticSelectOptionService) : ISearchService
    {
        private readonly IVehicleService _vehicleService = vehicleService;
        private readonly IUserService _userService = userService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IEmailService _emailService = emailService; 
        private readonly IConfiguration _config = config;
        private readonly IWebHostEnvironment _env = env;
        private readonly IStaticSelectOptionService _staticSelectOptionService = staticSelectOptionService;

        public IEnumerable<VehicleListDto> GetSearchResult(string VIN) 
        {
            try
            {
                var search = _vehicleService.GetAllVehicles().Where(e => e.VIN.Contains(VIN));
                if (search == null || !search.Any())
                {
                    SaveSearchHistory(VIN);
                }
                else
                {
                    SaveMatched(search.FirstOrDefault());
                }
                return (search == null || !search.Any()) ? [] : search;
            }
            catch
            {
                throw;
            }
        }

        private void SaveMatched(VehicleListDto? model)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Matches>();
                var getExisting = repository.FirstOrDefault(e=>e.VehicleId == model.Id);
                var entity = new Matches()
                {
                    AddedById = _userService.GetUserId(),
                    ModifiedById = _userService.GetUserId(),
                    AddedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    MatchedAt = DateTime.Now,
                    VehicleId = model.Id,
                    UserId = _userService.GetUserId(),
                    Notified = true,
                    Id = getExisting == null ? 0 : getExisting.Id
                };
                var res1 = repository.AddOrUpdate(v=>v.VehicleId == model.Id && v.UserId != model.UserId, entity);
                var res = repository.GetByInclude(v=>v.Id == res1.Id, v=>v.User, v => v.User.Businesses, v=>v.Vehicles, v=>v.Vehicles.Users);
                var facilityType = StatusOptions().FirstOrDefault(e => e.Value == res.Vehicles.Status.ToString()).Text;
                string CompanyEmail = res.Vehicles.Users.Email;
                string Name = _userService.GetClaimByType(ClaimTypes.Name);
                string Email = _userService.GetClaimByType(ClaimTypes.Email);
                var ContentToFill = GetVehicleImpoundEmail(Name, res.User.FullName, res.User.FullName, res.User.Businesses.Phone,
                    res.Vehicles.PickedOn.ToString("MM/dd/yyyy HH:MM"), res.User.Businesses.Address,"", facilityType);
                _emailService.SendEmail(Email, "Vehicle "+ facilityType + " Notification", ContentToFill, CompanyEmail, true);

            }
            catch
            {
                throw;
            }
        }

        private void SaveSearchHistory(string VIN) 
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Searches>();
                var entity = new Searches()
                { 
                    AddedById = _userService.GetUserId(),
                    ModifiedById = _userService.GetUserId(),
                    AddedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    SearchDate = DateTime.Now,
                    VIN = VIN,
                    UserId = _userService.GetUserId(),
                    Paid = true                    
                };
                var response = repository.AddOrUpdate(v => v.VIN == VIN && v.UserId == entity.UserId, entity);

                
            }
            catch
            {
                throw;
            }
        }
        private List<SelectListItem> StatusOptions()
        {
            return _staticSelectOptionService.StatusOptions();
        }
        private string GetVehicleImpoundEmail(string userName, string vin, string companyName, string companyPhone,
                                     string impoundDate, string companyAddress, string companyWebsite, string facilityType)
        { 
            var emailTemplate = File.ReadAllText(
               Path.Combine(_env.ContentRootPath, "wwwroot/EmailTemplates/matchnotification.html")
           );
            emailTemplate = emailTemplate.Replace("{{UserName}}", userName)
                                         .Replace("{{FacilityType}}", facilityType)
                                         .Replace("{{VIN}}", vin)
                                         .Replace("{{CompanyName}}", companyName)
                                         .Replace("{{CompanyPhone}}", companyPhone)
                                         .Replace("{{ImpoundDate}}", impoundDate)
                                         .Replace("{{CompanyAddress}}", companyAddress)
                                         //.Replace("{{CompanyWebsite}}", companyWebsite)
                                         .Replace("{{YourCompanyName}}", _config["ProductOwner:CompamyName"])
                                         .Replace("{{BaseUrl}}", _config["JwtSettings:Issuer"]) 
                                         .Replace("{{LogoLink}}", "https://www.impoundfinders.com/images/logo.png")
                                         .Replace("{{CopyRightYear}}", DateTime.Now.Year.ToString());

            return emailTemplate; 
        }
    }
}