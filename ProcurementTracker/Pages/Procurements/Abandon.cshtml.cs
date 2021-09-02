using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using ProcurementTracker.Shared;

namespace ProcurementTracker.Pages.Procurements
{
    public class AbandonModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;

        public AbandonModel(ProcurementTrackerContext context)
        {
            _context = context;
        }

        public Procurement Procurement { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            Procurement = await _context.Procurement.FirstOrDefaultAsync(p => p.Id == id.Value);
            if (Procurement == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromForm]Guid id)
        {
            Procurement = await _context.Procurement.FirstOrDefaultAsync(p => p.Id == id);
            if (Procurement == null) return NotFound();

            Procurement.Status = ProcurementStatus.ABANDONED.Value;

            await _context.SaveChangesAsync();

            return RedirectToPage("Details", new { id = Procurement.Id });
        }
    }
}
