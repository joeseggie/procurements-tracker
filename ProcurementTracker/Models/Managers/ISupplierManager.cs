using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Models.Managers
{
    /// <summary>
    /// Interface to manage operations to add, query and edit the supplier entity.
    /// </summary>
    public interface ISupplierManager
    {
        /// <summary>
        /// Get the suppliers list for the UI select list item.
        /// </summary>
        /// <returns>Select list items list</returns>
        List<SelectListItem> GetSuppliersSelectList();

        /// <summary>
        /// Get supplier by Id.
        /// </summary>
        /// <param name="id">Id of the supplier.</param>
        /// <returns>Supplier whose Id has been supplied.</returns>
        Task<Supplier?> GetSupplierAsync(Guid id);
    }
}
