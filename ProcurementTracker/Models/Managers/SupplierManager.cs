using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Models.Managers
{
    /// <summary>
    /// Manages operations to add, edit and query the Supplier entity.
    /// </summary>
    public class SupplierManager : ISupplierManager
    {
        private readonly ProcurementTrackerContext context;

        /// <summary>
        /// Initializes <see cref="SupplierManager"/>
        /// </summary>
        /// <param name="context">Database context.</param>
        public SupplierManager(ProcurementTrackerContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public List<SelectListItem> GetSuppliersSelectList()
        {
            if (context.Suppliers is null)
            {
                return new List<SelectListItem>();
            }

            return context.Suppliers.OrderBy(s => s.Name)
                                    .Select(s => new SelectListItem(s.Name, s.Id.ToString()))
                                    .ToList();
        }

        /// <inheritdoc/>
        public async Task<Supplier?> GetSupplierAsync(Guid supplierId)
        {
            if (context.Suppliers is null)
            {
                return null;
            }

            return await context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);
        }
    }
}
