using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Models;
using ProcurementTracker.Shared;

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

        public async Task<IActionResult> OnGetAsync(Guid? id)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Bid.Status = BidStatus.REJECTED.ToString();
            _context.Attach(Bid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidExists(Bid.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Details", new { id = Bid.Id, procurementid = Bid.Procurement.Id });
        }

        private bool BidExists(Guid id)
        {
            return _context.Bid.Any(e => e.Id == id);
        }
    }
}
