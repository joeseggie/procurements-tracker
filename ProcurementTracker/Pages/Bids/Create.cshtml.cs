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
        private readonly ProcurementTrackerContext context;
        private readonly ISupplierManager supplierManager;

        public List<SelectListItem>? Currencies { get; set; } = ChoicesList.Create<Currency>();

        public Procurement? Procurement { get; set; }

        [BindProperty]
        public Bid? Bid { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid? ProcurementId { get; set; }

        [BindProperty]
        public Guid? SupplierId { get; set; }

        public List<SelectListItem>? Suppliers { get; set; }

        public CreateModel(ProcurementTrackerContext context, ISupplierManager supplierManager)
        {
            this.context = context;
            this.supplierManager = supplierManager;
        }

        public async Task<IActionResult> OnGetAsync(Guid procurementId)
        {
            if (context.Procurements is not null)
            {
                Procurement = await context.Procurements.FirstOrDefaultAsync(p => p.Id == procurementId);
            }
            Suppliers = supplierManager.GetSuppliersSelectList();
            return Page();
        }

        private async void SetBidProcurement()
        {
            if (context.Procurements is not null && Bid is not null)
            {
                Bid.Procurement = await context.Procurements.FirstOrDefaultAsync(p => p.Id == ProcurementId);
            }
        }

        private void SetBidStatus()
        {
            if (Bid is not null)
            {
                Bid.Status = BidStatus.RECEIVED.Value; 
            }
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SetBidProcurement();
            if (Bid is not null && SupplierId.HasValue)
            {
                Bid.Supplier = await supplierManager.GetSupplierAsync(SupplierId.Value);
            }
            SetBidStatus();

            if (context.Bids is not null && Bid is not null)
            {
                await context.Bids.AddAsync(Bid);
            }
            await context.SaveChangesAsync();

            return RedirectToPage("Details", new { id = Bid?.Id, procurementid = ProcurementId });
        }
    }
}
