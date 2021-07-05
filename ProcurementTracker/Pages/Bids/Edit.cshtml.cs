using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;

namespace ProcurementTracker.Pages.Bids
{
    public class EditModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public EditModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bid Bid { get; set; }

        public bool HasProcurementFilter { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(Guid? id, Guid? procurementid)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (procurementid == null)
            {
                Bid = await _context.Bid
                                    .Include(m => m.Supplier)
                                    .Include(m => m.Procurement)
                                    .FirstOrDefaultAsync(m => m.Id == id); 
            }
            else
            {
                Bid = await _context.Bid
                                    .Include(m => m.Supplier)
                                    .Include(m => m.Procurement)
                                    .FirstOrDefaultAsync(m => m.Id == id && m.Procurement.Id == procurementid);
                
                HasProcurementFilter = true;
            }

            if (Bid == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

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

            return RedirectToPage("./Details", new { id = Bid.Id, procurementid = Bid.Procurement.Id});
        }

        private bool BidExists(Guid id)
        {
            return _context.Bid.Any(e => e.Id == id);
        }
    }
}
