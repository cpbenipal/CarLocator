using AutoMapper;
using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Application.Services;
using CLIMFinders.Domain.Entities;
using CLIMFinders.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLIMFinders.Web.Areas.Business.Pages
{
    [Authorize(Roles = "Tow,Impound")]
    public class SaveVehicleModel(IVehicleService vehicleService) : PageModel
    {
        private readonly IVehicleService vehicleService = vehicleService;
        public List<SelectListItem> VehicleColors { get; set; }
        public List<SelectListItem> VehicleMakes { get; set; }
        public List<SelectListItem> ModelYear { get; set; }
        public List<SelectListItem> StatusOptions { get; set; }

        public void OnGet(int? id)
        {
            VehicleMakes = vehicleService.GetVehicleMakes();
            VehicleColors = vehicleService.GetVehicleColors();
            ModelYear = vehicleService.PopulateYear();
            StatusOptions = vehicleService.StatusOptions();
            if (id.HasValue)
            {
                GetVehicle(id.Value);
            }
        }

        private void GetVehicle(int value)
        {
            Input.Id = value;
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = vehicleService.SaveVehicle(Input);
            if (result.Id > 0)
            {
                return RedirectToPage("/ManageVehicals", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError(string.Empty, result.Status);
            }
            return Page();
        }
        [BindProperty]
        public VehicleDto Input { get; set; } = new();
    }
}
