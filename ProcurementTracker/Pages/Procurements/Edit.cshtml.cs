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
using ProcurementTracker.Shared;

namespace ProcurementTracker.Pages.Procurements
{
    public class EditModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public EditModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Procurement Procurement { get; set; }
        public List<SelectListItem> ProcurementStatuses { get; set; } = ChoicesList.Create<ProcurementStatus>();
        public List<SelectListItem> ProcurementMethods { get; set; } = ChoicesList.Create<ProcurementMethod>();

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procurement = await _context.Procurement.FirstOrDefaultAsync(m => m.Id == id);

            if (Procurement == null)
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

            _context.Attach(Procurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcurementExists(Procurement.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProcurementExists(Guid id)
        {
            return _context.Procurement.Any(e => e.Id == id);
        }
    }
}
