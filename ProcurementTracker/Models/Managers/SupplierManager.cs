using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Models.Managers
{
    public class SupplierManager : ISupplierManager
    {
        private readonly ProcurementTrackerContext _context;

        public SupplierManager(ProcurementTrackerContext context)
        {
            _context = context;
        }
        public List<SelectListItem> GetSuppliersSelectList()
        {
            return _context.Supplier.OrderBy(s => s.Name)
                                    .Select(s => new SelectListItem(s.Name, s.Id.ToString()))
                                    .ToList();
        }

        public async Task<Supplier> GetSupplierAsync(Guid supplierId)
        {
            return await _context.Supplier.FirstOrDefaultAsync(s => s.Id == supplierId);
        }
    }
}
