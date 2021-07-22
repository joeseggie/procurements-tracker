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

        public List<SelectListItem> Currencies { get; set; } = ChoicesList.Create<Currency>();

        public List<SelectListItem> ProcurementTypes { get; set; } = ChoicesList.Create<ProcurementType>();

        public List<SelectListItem> FundingSources { get; set; } = ChoicesList.Create<FundingSource>();

        public bool HideBasicDataSection { get; set; }

        public bool DisableBasicDataSection { get; set; }

        public bool HideInititationAndEoIRequestSection { get; set; }

        public bool DisableInitiationAndEoIRequestSection { get; set; }

        public bool HideBiddingPeriodSection { get; set; }

        public bool DisableBiddingPeriodSection { get; set; }

        public bool HideBidsEvaluationSection { get; set; }

        public bool DisableBidsEvaluationSection { get; set; }

        public bool HideNegotiationSection { get; set; }

        public bool DisableNegotiationSection { get; set; }

        public bool HideAdministrativeReview { get; set; }

        public bool DisableAdministrativeReview { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procurement = await _context.Procurement.FirstOrDefaultAsync(m => m.Id == id);

            HideOrDisabledSections();

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

        private void HideOrDisabledSections()
        {
            switch (Procurement.Status)
            {
                case "NOT STARTED":
                    HideBasicDataSection = false;
                    DisableBasicDataSection = false;
                    HideInititationAndEoIRequestSection = true;
                    DisableInitiationAndEoIRequestSection = false;
                    HideBiddingPeriodSection = true;
                    DisableBiddingPeriodSection = false;
                    HideBidsEvaluationSection = true;
                    DisableBidsEvaluationSection = false;
                    HideNegotiationSection = true;
                    DisableNegotiationSection = false;
                    HideAdministrativeReview = true;
                    DisableAdministrativeReview = false;
                    break;
                case "ASSESSMENT OF MARKET PRICE":
                case "PROCUREMENT REQUISITIONS":
                case "CONFIRMATION OF AVAILABILITY OF FUNDS":
                case "REVIEW AND PREPARATION OF BIDDING DOCUMENTS":
                case "APPROVAL OF PROCUREMENT METHOD, BIDDING DOCUMENTS AND EVALUATION COMMITTEE":
                    HideBasicDataSection = false;
                    DisableBasicDataSection = false;
                    HideInititationAndEoIRequestSection = false;
                    DisableInitiationAndEoIRequestSection = false;
                    HideBiddingPeriodSection = true;
                    DisableBiddingPeriodSection = false;
                    HideBidsEvaluationSection = true;
                    DisableBidsEvaluationSection = false;
                    HideNegotiationSection = true;
                    DisableNegotiationSection = false;
                    HideAdministrativeReview = true;
                    DisableAdministrativeReview = false;
                    break;
                case "ADVERTISING AND INVITATION OF BIDS":
                case "RECEIPT AND OPENING OF BIDS":
                    HideBasicDataSection = false;
                    DisableBasicDataSection = true;
                    HideInititationAndEoIRequestSection = false;
                    DisableInitiationAndEoIRequestSection = true;
                    HideBiddingPeriodSection = false;
                    DisableBiddingPeriodSection = false;
                    HideBidsEvaluationSection = true;
                    DisableBidsEvaluationSection = false;
                    HideNegotiationSection = true;
                    DisableNegotiationSection = false;
                    HideAdministrativeReview = true;
                    DisableAdministrativeReview = false;
                    break;
                case "EVALUATION OF BIDS":
                    HideBasicDataSection = false;
                    DisableBasicDataSection = true;
                    HideInititationAndEoIRequestSection = false;
                    DisableInitiationAndEoIRequestSection = true;
                    HideBiddingPeriodSection = false;
                    DisableBiddingPeriodSection = true;
                    HideBidsEvaluationSection = false;
                    DisableBidsEvaluationSection = false;
                    HideNegotiationSection = true;
                    DisableNegotiationSection = false;
                    HideAdministrativeReview = true;
                    DisableAdministrativeReview = false;
                    break;
                case "AWARD OF CONTRACT":
                case "BEB PRICE REASSESSMENT":
                    HideBasicDataSection = false;
                    DisableBasicDataSection = true;
                    HideInititationAndEoIRequestSection = false;
                    DisableInitiationAndEoIRequestSection = true;
                    HideBiddingPeriodSection = false;
                    DisableBiddingPeriodSection = true;
                    HideBidsEvaluationSection = false;
                    DisableBidsEvaluationSection = true;
                    HideNegotiationSection = false;
                    DisableNegotiationSection = false;
                    HideAdministrativeReview = true;
                    DisableAdministrativeReview = false;
                    break;
                case "ADMINISTRATIVE REVIEW":
                    HideBasicDataSection = false;
                    DisableBasicDataSection = true;
                    HideInititationAndEoIRequestSection = false;
                    DisableInitiationAndEoIRequestSection = true;
                    HideBiddingPeriodSection = false;
                    DisableBiddingPeriodSection = true;
                    HideBidsEvaluationSection = false;
                    DisableBidsEvaluationSection = true;
                    HideNegotiationSection = false;
                    DisableNegotiationSection = true;
                    HideAdministrativeReview = false;
                    DisableAdministrativeReview = false;
                    break;
                default:
                    HideBasicDataSection = false;
                    DisableBasicDataSection = true;
                    HideInititationAndEoIRequestSection = false;
                    DisableInitiationAndEoIRequestSection = true;
                    HideBiddingPeriodSection = false;
                    DisableBiddingPeriodSection = true;
                    HideBidsEvaluationSection = false;
                    DisableBidsEvaluationSection = true;
                    HideNegotiationSection = false;
                    DisableNegotiationSection = true;
                    HideAdministrativeReview = false;
                    DisableAdministrativeReview = true;
                    break;
            }
        }
    }
}
