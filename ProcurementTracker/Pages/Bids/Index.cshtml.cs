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
    public class IndexModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public IndexModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        public IList<Bid> Bid { get;set; }

        public Guid ProcurementId { get; set; }

        public async Task OnGetAsync(Guid? procurementid)
        {
            if (procurementid != null && Guid.TryParse(procurementid.ToString(), out Guid suppliedProcurementId))
            {
                ProcurementId = suppliedProcurementId;
                Bid = await _context.Bid
                                        .Where(b => b.Procurement.Id == ProcurementId)
                                        .Include(b => b.Supplier)
                                        .ToListAsync();
            }
        }
    }
}
