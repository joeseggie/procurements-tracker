using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Models;

namespace ProcurementTracker.Pages.Bids
{
    public class RejectModel : PageModel
    {
        public readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public RejectModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bid Bid { get; set; }

        public async Task<IActionResult> OnGet(Guid? id)
        {
            if (id == null)
                return NotFound();

            Bid = await _context.Bid
                                .Include(b => b.Procurement)
                                .FirstOrDefaultAsync(b => b.Id == id);
            if (Bid is null)
                return NotFound();

            return Page();
        }
    }
}
