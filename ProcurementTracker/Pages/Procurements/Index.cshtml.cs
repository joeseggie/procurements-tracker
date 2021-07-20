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
    public class IndexModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public IndexModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        public IList<Procurement> Procurement { get;set; }

        public async Task OnGetAsync()
        {
            Procurement = await _context.Procurement.ToListAsync();
        }

        public string DisplayProcurementPlan(bool isPlanned)
        {
            return isPlanned ? "PROCUREMENT PLAN" : "BUDGET";
        }
    }
}
