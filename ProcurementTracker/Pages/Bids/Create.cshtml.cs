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
using ProcurementTracker.Models.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Pages.Bids
{
    [Authorize(Policy = "CanCreateBid")]
    public class CreateModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;
        private readonly ISupplierManager _supplierManager;

        public List<SelectListItem> Currencies { get; set; } = ChoicesList.Create<Currency>();

        public CreateModel(ProcurementTrackerContext context, ISupplierManager supplierManager)
        {
            _context = context;
            _supplierManager = supplierManager;
        }

        public async Task<IActionResult> OnGetAsync(Guid procurementid)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(p => p.Id == procurementid);
            Suppliers = _supplierManager.GetSuppliersSelectList();
            return Page();
        }

        public Procurement Procurement { get; set; }

        [BindProperty]
        public Bid Bid { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid ProcurementId { get; set; }

        [BindProperty]
        public Guid SupplierId { get; set; }

        public List<SelectListItem> Suppliers { get; set; }

        private async void SetBidProcurement()
        {
            Bid.Procurement = await _context.Procurements.FirstOrDefaultAsync(p => p.Id == ProcurementId);
        }

        private void SetBidStatus()
        {
            Bid.Status = BidStatus.RECEIVED.Value;
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SetBidProcurement();
            Bid.Supplier = await _supplierManager.GetSupplierAsync(SupplierId);
            SetBidStatus();

            await _context.Bids.AddAsync(Bid);
            await _context.SaveChangesAsync();

            return RedirectToPage("Details", new { id = Bid.Id, procurementid = ProcurementId });
        }
    }
}
