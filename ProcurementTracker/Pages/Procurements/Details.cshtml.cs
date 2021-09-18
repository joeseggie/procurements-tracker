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
        private readonly ProcurementTrackerContext _context;

        public DetailsModel(ProcurementTrackerContext context)
        {
            _context = context;
        }

        public Procurement Procurement { get; set; }

        public bool HideStartButton { get; set; } = true;

        public bool HideIssueContractButton { get; set; } = true;

        public bool HideAbandonButton { get; set; } = true;

        public bool HideMarketAssessmentButton { get; set; } = true;

        public bool HideProcurementRequisitionsButton { get; set; } = true;

        public bool HideFundsConfirmButton { get; set; } = true;

        public bool HidePrepBiddingDocsButton { get; set; } = true;

        public bool HideEvaluationCommitteeApprovalButton { get; set; } = true;

        public bool HideBidsInvitationsButton { get; set; } = true;

        public bool HideReceiveBidsButton { get; set; } = true;

        public bool HideEvaluateBidsButton { get; set; } = true;

        public bool HideAwardContractButton { get; set; } = true;

        public bool HideBEBPriceReviewButton { get; set; } = true;

        public bool HideAdministrativeReviewButton { get; set; } = true;

        public bool HideBidsViewButton { get; set; } = true;

        public bool DisableProcurementEdit { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);

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
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = true;
                    break;
                case "ASSESSMENT OF MARKET PRICE":
                    HideStartButton = true;
                    HideMarketAssessmentButton = false;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = true;
                    break;
                case "PROCUREMENT REQUISITIONS":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = false;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = true;
                    break;
                case "CONFIRMATION OF AVAILABILITY OF FUNDS":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = false;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = true;
                    break;
                case "REVIEW AND PREPARATION OF BIDDING DOCUMENTS":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = false;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = true;
                    break;
                case "APPROVAL OF PROCUREMENT METHOD, BIDDING DOCUMENTS AND EVALUATION COMMITTEE":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = false;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = true;
                    break;
                case "ADVERTISING AND INVITATION OF BIDS":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = false;
                    HideReceiveBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = true;
                    break;
                case "RECEIPT AND OPENING OF BIDS":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = false;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = false;
                    break;
                case "EVALUATION OF BIDS":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideEvaluateBidsButton = false;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = false;
                    break;
                case "AWARD OF CONTRACT":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideEvaluateBidsButton = true;
                    HideAwardContractButton = false;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = false;
                    break;
                case "BEB PRICE REASSESSMENT":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideEvaluateBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = false;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = false;
                    break;
                case "ADMINISTRATIVE REVIEW":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideEvaluateBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = false;
                    HideIssueContractButton = true;
                    HideAbandonButton = false;
                    DisableProcurementEdit = false;
                    HideBidsViewButton = false;
                    break;
                case "CONTRACT SIGNING":
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideEvaluateBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = false;
                    HideAbandonButton = false;
                    DisableProcurementEdit = true;
                    HideBidsViewButton = false;
                    break;
                case "CONTRACT ISSUED":
                case "ABANDONED":
                default:
                    HideStartButton = true;
                    HideMarketAssessmentButton = true;
                    HideProcurementRequisitionsButton = true;
                    HideFundsConfirmButton = true;
                    HidePrepBiddingDocsButton = true;
                    HideEvaluationCommitteeApprovalButton = true;
                    HideBidsInvitationsButton = true;
                    HideReceiveBidsButton = true;
                    HideEvaluateBidsButton = true;
                    HideAwardContractButton = true;
                    HideBEBPriceReviewButton = true;
                    HideAdministrativeReviewButton = true;
                    HideIssueContractButton = true;
                    HideAbandonButton = true;
                    DisableProcurementEdit = true;
                    HideBidsViewButton = false;
                    break;
            }
        }

        public IActionResult OnPostAbandon(Guid id)
        {
            return RedirectToPage("Abandon", new { id });
        }

        public async Task<IActionResult> OnPostStart(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.NOT_STARTED.Value)
            {
                Procurement.Status = ProcurementStatus.MARKET_PRICE_ASSESSMENT.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostAssessMarket(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.MARKET_PRICE_ASSESSMENT.Value)
            {
                Procurement.Status = ProcurementStatus.PROCUREMENT_REQUISITIONS.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostProcurementRequisitions(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.PROCUREMENT_REQUISITIONS.Value)
            {
                Procurement.Status = ProcurementStatus.FUNDS_AVAILABILITY_CONFIRMATION.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostConfirmFunds(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.FUNDS_AVAILABILITY_CONFIRMATION.Value)
            {
                Procurement.Status = ProcurementStatus.BIDDING_DOCUMENTS_PREPARATION.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostPrepBiddingDocs(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.BIDDING_DOCUMENTS_PREPARATION.Value)
            {
                Procurement.Status = ProcurementStatus.PMBDEC_APPROVAL.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostApproveEvaluationCommittee(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.PMBDEC_APPROVAL.Value)
            {
                Procurement.Status = ProcurementStatus.BIDS_INVITATION.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostInviteBids(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.BIDS_INVITATION.Value)
            {
                Procurement.Status = ProcurementStatus.BIDS_RECEIPT_AND_OPENING.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostReceiveBids(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.BIDS_RECEIPT_AND_OPENING.Value)
            {
                Procurement.Status = ProcurementStatus.BIDS_EVALUATION.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostEvaluateBids(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.BIDS_EVALUATION.Value)
            {
                Procurement.Status = ProcurementStatus.CONTRACT_AWARD.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostAwardContract(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.CONTRACT_AWARD.Value)
            {
                Procurement.Status = ProcurementStatus.BEB_PRICE_REVIEW.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostReviewBEBPrice(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.BEB_PRICE_REVIEW.Value)
            {
                Procurement.Status = ProcurementStatus.ADMINISTRATIVE_REVIEW.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostAdministrativeReview(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.ADMINISTRATIVE_REVIEW.Value)
            {
                Procurement.Status = ProcurementStatus.CONTRACT_SIGNING.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }

        public async Task<IActionResult> OnPostSignContract(Guid id)
        {
            Procurement = await _context.Procurements.FirstOrDefaultAsync(m => m.Id == id);
            if (Procurement != null && Procurement.Status == ProcurementStatus.CONTRACT_SIGNING.Value)
            {
                Procurement.Status = ProcurementStatus.CONTRACT_ISSUED.Value;
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Procurement.Id });
        }
    }
}
