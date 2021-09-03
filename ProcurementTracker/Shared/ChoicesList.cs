using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared
{
    public static class ChoicesList
    {
        public static List<SelectListItem> Create<T>(bool includeEmptyOption = false)
        {
            var type = typeof(T);
            List<SelectListItem> result = type.GetProperties()
                                              .Where(p => p.Name != "Value")
                                              .Select(p => new SelectListItem(p.GetValue(null).ToString(),
                                                                              p.GetValue(null).ToString(), 
                                                                              IsSelected<T>(p.GetValue(null).ToString())))
                                              .OrderBy(p => p.Text)
                                              .ToList();

            if (includeEmptyOption)
            {
                result.Insert(0, new SelectListItem("Pick an option", ""));
            }
            return result;
        }

        private static bool IsSelected<T>(string option)
        {
            bool optionSelected = false;
            if (typeof(T) == typeof(Currency))
                optionSelected = option == "UGX";

            return optionSelected;
        }
    }
}
