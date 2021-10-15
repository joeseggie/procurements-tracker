using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;

namespace ProcurementTracker.Pages.Bids
{
    [Authorize(Policy = "CanReadBid")]
    public class IndexModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;

        public IndexModel(ProcurementTrackerContext context)
        {
            _context = context;
        }

        public IList<Bid> Bid { get;set; }

        public Guid ProcurementId { get; set; }
        public Procurement Procurement { get; set; }

        public bool HasProcurementFilter { get; set; } = false;

        public async Task OnGetAsync(Guid? procurementid)
        {
            Bid = await _context.Bids
                          .Include(b => b.Supplier)
                          .Include(b => b.Procurement)
                          .ToListAsync();

            if (procurementid != null && Guid.TryParse(procurementid.ToString(), out Guid suppliedProcurementId))
            {
                ProcurementId = suppliedProcurementId;
                Bid = Bid.Where(b => b.Procurement?.Id == ProcurementId)
                         .ToList();

                HasProcurementFilter = true;
                Procurement = await _context.Procurements.FirstOrDefaultAsync(p => p.Id == ProcurementId);
            }
        }
    }
}
