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

        public bool HideCloseButton { get; set; } = true;

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
                    HideCloseButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    break;
                case "IN PROGRESS":
                    HideStartButton = true;
                    HideCloseButton = false;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    break;
                case "CLOSED":
                case "ABANDONED":
                default:
                    HideStartButton = true;
                    HideCloseButton = true;
                    HideAbandonButton = true;
                    DisableProcurementEdit = true;
                    break;
            }
        }

        public async Task<IActionResult> OnPostAbandon(Guid id)
        {
            Procurement = await _context.Procurement.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status != ProcurementStatus.CLOSED.Value)
            {
                Procurement.Status = ProcurementStatus.ABANDONED.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostStart(Guid id)
        {
            Procurement = await _context.Procurement.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.NOTSTARTED.Value)
            {
                Procurement.Status = ProcurementStatus.INPROGRESS.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostClose(Guid id)
        {
            Procurement = await _context.Procurement.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.INPROGRESS.Value)
            {
                Procurement.Status = ProcurementStatus.CLOSED.Value;
                _context.SaveChanges();

                HideCloseButton = false;
                HideStartButton = true;
                HideAbandonButton = false;
            }

            return RedirectToPage("Details", new { id = Procurement.Id});
        }
    }
}
