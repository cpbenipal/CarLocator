using CLIMFinders.Application.Enums;
using CLIMFinders.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class StaticSelectOptionService : IStaticSelectOptionService
    {
        public List<SelectListItem> StatusOptions()
        {
            var options = new List<SelectListItem>
            {
                new() { Value = "1", Text = "Impounded" },
                new() { Value = "2", Text = "Tow" },
                new() { Value = "3", Text = "Released" }
            };
            return options;
        }
        public List<SelectListItem> RoleOptions() 
        {
            var options = new List<SelectListItem>
            {
                new SelectListItem { Text = RoleEnum.Users.ToString(), Value = ((int)RoleEnum.Users).ToString() },
                new SelectListItem { Text = RoleEnum.Tow.ToString(), Value = ((int)RoleEnum.Tow).ToString() },
                new SelectListItem { Text = RoleEnum.Impound.ToString(),Value = ((int)RoleEnum.Impound).ToString() }
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

            return years;
        }
    }
}
