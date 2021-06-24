using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Models.Managers
{
    public interface ISupplierManager
    {
        List<SelectListItem> GetSuppliersSelectList();
        Task<Supplier> GetSupplierAsync(Guid supplierId);
    }
}
