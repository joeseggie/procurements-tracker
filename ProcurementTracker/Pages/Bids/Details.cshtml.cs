using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;

namespace ProcurementTracker.Pages.Bids
{
    public class DetailsModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public DetailsModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        public Bid Bid { get; set; }

        public bool HasProcurementFilter { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(Guid? id, Guid? procurementid)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (procurementid != null)
            {
                Bid = await _context.Bid.Include(m => m.Supplier).Include(m => m.Procurement).FirstOrDefaultAsync(m => m.Id == id && m.Procurement.Id == procurementid);
                HasProcurementFilter = true;
            }
            else
            {
                Bid = await _context.Bid.Include(m => m.Supplier).Include(m => m.Procurement).FirstOrDefaultAsync(m => m.Id == id);
            }

            if (Bid == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
