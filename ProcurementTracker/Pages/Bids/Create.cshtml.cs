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

namespace ProcurementTracker.Pages.Bids
{
    public class CreateModel : PageModel
    {
        private readonly ProcurementTrackerContext _context;
        private readonly ISupplierManager _supplierManager;

        public CreateModel(ProcurementTrackerContext context, ISupplierManager supplierManager)
        {
            _context = context;
            _supplierManager = supplierManager;
        }

        public IActionResult OnGet()
        {
            Suppliers = _supplierManager.GetSuppliersSelectList();
            return Page();
        }

        [BindProperty]
        public Bid Bid { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid ProcurementId { get; set; }

        [BindProperty]
        public Guid SupplierId { get; set; }

        public List<SelectListItem> Suppliers { get; set; }

        private void SetBidProcurement()
        {
            Bid.Procurement = _context.Procurement.FirstOrDefault(p => p.Id == ProcurementId);
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

            _context.Bid.Add(Bid);
            await _context.SaveChangesAsync();

            return RedirectToPage("Details", new { id = Bid.Id });
        }
    }
}
