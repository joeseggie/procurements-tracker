using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using ProcurementTracker.Shared;

namespace ProcurementTracker.Pages.Procurements
{
    public class DetailsModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public DetailsModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        public Procurement Procurement { get; set; }

        public bool HideStartButton { get; set; } = true;

        public bool HideIssuContractButton { get; set; } = true;

        public bool HideAbandonButton { get; set; } = true;

        public bool DisableProcurementEdit { get; set; }

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

            ShowHideActionBarButtons(Procurement.Status);

            return Page();
        }

        private void ShowHideActionBarButtons(string status)
        {
            switch (status)
            {
                case "NOT STARTED":
                    HideStartButton = false;
                    HideIssuContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    break;
                case "CONTRACT SIGNING":
                    HideStartButton = true;
                    HideIssuContractButton = false;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    break;
                case "CONTRACT ISSUED":
                case "ABANDONED":
                default:
                    HideStartButton = true;
                    HideIssuContractButton = true;
                    HideAbandonButton = true;
                    DisableProcurementEdit = true;
                    break;
            }
        }

        public async Task<IActionResult> OnPostAbandon(Guid id)
        {
            Procurement = await _context.Procurement.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status != ProcurementStatus.CONTRACT_ISSUED.Value)
            {
                Procurement.Status = ProcurementStatus.ABANDONED.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostStart(Guid id)
        {
            Procurement = await _context.Procurement.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.NOT_STARTED.Value)
            {
                Procurement.Status = ProcurementStatus.MARKET_PRICE_ASSESSMENT.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostIssueContract(Guid id)
        {
            Procurement = await _context.Procurement.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.CONTRACT_SIGNING.Value)
            {
                Procurement.Status = ProcurementStatus.CONTRACT_ISSUED.Value;
                _context.SaveChanges();

                HideIssuContractButton = false;
                HideStartButton = true;
                HideAbandonButton = false;
            }

            return RedirectToPage("Details", new { id = Procurement.Id});
        }
    }
}
