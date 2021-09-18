using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using ProcurementTracker.Shared;

namespace ProcurementTracker.Pages.Procurements
{
    public class CreateModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public CreateModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Procurement Procurement { get; set; }

        public List<SelectListItem> ProcurementMethods { get; set; } = ChoicesList.Create<ProcurementMethod>();

        public List<SelectListItem> Currencies { get; set; } = ChoicesList.Create<Currency>();

        public List<SelectListItem> ProcurementTypes { get; set; } = ChoicesList.Create<ProcurementType>();

        public List<SelectListItem> FundingSources { get; set; } = ChoicesList.Create<FundingSource>();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Procurement.Status = ProcurementStatus.NOT_STARTED.Value;

            _context.Procurements.Add(Procurement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
