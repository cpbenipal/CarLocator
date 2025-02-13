using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CLIMFinders.Web.Areas.Business.Pages
{
    [Authorize(Roles = "Tow,Impound")]
    public class ManageVehicalsModel(IVehicleService vehicleService) : PageModel
    {
        private readonly IVehicleService vehicleService = vehicleService;

        public void OnGet()
        {
            Input = vehicleService.GetVehicles();
        }
        [BindProperty]
        public List<VehicleListDto> Input { get; set; } = new();
    }
}
