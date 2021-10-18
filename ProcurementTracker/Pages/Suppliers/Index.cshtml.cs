using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcurementTracker.Pages.Suppliers
{
    [Authorize(Policy = "CanReadSupplier")]
    public class IndexModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;

        public IndexModel(ProcurementTrackerContext context)
        {
            _context = context;
        }

        public IList<Supplier>? Supplier { get;set; }

        public async Task OnGetAsync()
        {
            Supplier = await _context.Suppliers.ToListAsync();
        }
    }
}
