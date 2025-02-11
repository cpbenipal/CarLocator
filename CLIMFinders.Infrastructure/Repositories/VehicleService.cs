using AutoMapper;
using Azure;
using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Domain.Entities;
using Given.DataContext.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public List<VehicleListDto> GetVehicles() 
        {
            try
            {
                var repository = unitOfWork.GetRepository<Vehicles>();
                var response = repository.GetAllInclude().ToList();

                var lstVehicles = mapper.Map<List<VehicleListDto>>(response);
                lstVehicles.ForEach(v =>
                {
                    v.BoundStatus = v.Status.ToString();
                });

                return lstVehicles;
            }
            catch
            {
                throw;
            }
        }
        public List<SelectListItem> GetVehicleColors()
        {
            try
            {
                var repository = unitOfWork.GetRepository<VehicleColor>();
                var response = repository.GetAll();
                return DropdownHelper.GetDropdownList(response, e => e.Id, e => e.Name);
            }
            catch
            {
                throw;
            }
        }
        public List<SelectListItem> GetVehicleMakes()
        {
            try
            {
                var repository = unitOfWork.GetRepository<VehicleMake>();
                var response = repository.GetAll();
                return DropdownHelper.GetDropdownList(response, e => e.Id, e => e.Name);
            }
            catch
            {
                throw;
            }
        }
        public List<SelectListItem> GetVehicleModel(int Id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<VehicleModel>();
                var response = repository.GetAll().Where(e => Id == 0 || e.Id == Id);
                return DropdownHelper.GetDropdownList(response, e => e.Id, e => e.Name);
            }
            catch
            {
                throw;
            }
        }
        public List<SelectListItem> StatusOptions()
        {
            var options = new List<SelectListItem>
            {
                new() { Value = "1", Text = "Impounded" },
                new() { Value = "2", Text = "Released" }
            };
            return options;
        }
        public List<SelectListItem> PopulateYear()
        {
            int startYear = 1900;
            int currentYear = DateTime.Now.Year;

            var years = new List<SelectListItem>();
             
            for (int year = currentYear; year >= startYear; year--)
            {
                years.Add(new SelectListItem { Value = year.ToString(), Text = year.ToString() });
            }

            return DropdownHelper.GetDropdownList(years, e => e.Value, e => e.Text);
        }
        public ResponseDto SaveVehicle(VehicleDto vehicle)
        {
            ResponseDto response = new();
            try
            {
                response = AddOrUpdateVehicle(vehicle);
            }
            catch
            {
                response.Status = "An unexpected error occurred";
                throw;
            }
            return response;
        }

        private ResponseDto AddOrUpdateVehicle(VehicleDto model)
        {
            ResponseDto response = new();
            var repository = unitOfWork.GetRepository<Vehicles>();
            if (IsVehicleExists(model.VIN, model.Id))
            {
                response.Id = -1;
                response.Name = model.VIN;
                response.Status = "Vehicle already exists";
            }
            else
            {
                if (model.Id > 0)
                {
                    var mappedObj = mapper.Map<Vehicles>(model);
                    mappedObj.AddedById = mappedObj.ModifiedById = model.LoginId;
                    var entity = repository.Insert(mappedObj);
                    response.Id = entity.Id;
                    response.Name = entity.VIN;
                    response.Status = "Vehicle detail added successfully";
                }
                else
                {
                    var detail = repository.GetById(model.Id);
                    detail.BusinessId = model.BusinessId;
                    detail.Status = model.Status;
                    detail.VIN = model.VIN;
                    detail.ColorId = model.ColorId;
                    detail.MakeId = model.MakeId;
                    detail.ModelId = model.ModelId;
                    detail.Note = model.Note;
                    detail.PickedOn = model.PickedOn;
                    detail.Year = model.Year;
                    detail.ModifiedById = model.LoginId;
                    repository.Update(detail);
                    response.Id = detail.Id;
                    response.Name = detail.VIN;
                    response.Status = "Vehicle detail updated successfully";
                }
                repository.Save();
            }
            return response;
        }

        bool IsVehicleExists(string vIN, int Id)
        {
            var repository = unitOfWork.GetRepository<Vehicles>();
            return repository != null && repository.GetAll().Any(x => x.VIN == vIN && x.Id == Id);
        }
    }
}
