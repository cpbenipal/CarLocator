using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class DropdownHelper
    {
        public static List<SelectListItem> GetDropdownList<T>(
            IEnumerable<T> items,
            Expression<Func<T, object>> valueSelector,
            Expression<Func<T, object>> textSelector)
        {
            try
            {
                return items.Select(item => new SelectListItem
                {
                    Value = valueSelector.Compile()(item)?.ToString(),
                    Text = textSelector.Compile()(item)?.ToString()
                }).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
