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

namespace ProcurementTracker.Pages.Bids
{
    public class DetailsModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public DetailsModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        public Bid Bid { get; set; }

        public bool HasProcurementFilter { get; set; } = false;

        public bool HideEditButton { get; set; } = true;

        public bool HideOpenBidButton { get; set; } = true;

        public bool HideStartBidEvaluationButton { get; set; } = true;

        public bool HideCloseBidEvaluationButton { get; set; } = true;

        public bool HideAcceptBidButton { get; set; } = true;

        public async Task<IActionResult> OnGetAsync(Guid? id, Guid? procurementid)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (procurementid != null)
            {
                Bid = await _context.Bid.Include(m => m.Supplier).Include(m => m.Procurement).FirstOrDefaultAsync(m => m.Id == id && m.Procurement.Id == procurementid);
                HasProcurementFilter = true;
            }
            else
            {
                Bid = await _context.Bid.Include(m => m.Supplier).Include(m => m.Procurement).FirstOrDefaultAsync(m => m.Id == id);
            }

            if (Bid == null)
            {
                return NotFound();
            }

            ShowHideActionBarButtons(Bid.Status);

            return Page();
        }

        private void ShowHideActionBarButtons(string bidStatus)
        {
            switch (bidStatus)
            {
                case "RECEIVED":
                    HideAcceptBidButton = true;
                    HideCloseBidEvaluationButton = true;
                    HideEditButton = true;
                    HideOpenBidButton = false;
                    HideStartBidEvaluationButton = true;
                    break;
                case "OPENED":
                    HideAcceptBidButton = true;
                    HideCloseBidEvaluationButton = true;
                    HideEditButton = false;
                    HideOpenBidButton = true;
                    HideStartBidEvaluationButton = false;
                    break;
                case "UNDER EVALUATION":
                    HideAcceptBidButton = true;
                    HideCloseBidEvaluationButton = false;
                    HideEditButton = true;
                    HideOpenBidButton = true;
                    HideStartBidEvaluationButton = true;
                    break;
                case "EVALUATED":
                    HideAcceptBidButton = false;
                    HideCloseBidEvaluationButton = true;
                    HideEditButton = true;
                    HideOpenBidButton = true;
                    HideStartBidEvaluationButton = true;
                    break;
                case "ACCEPTED":
                default:
                    HideAcceptBidButton = true;
                    HideCloseBidEvaluationButton = true;
                    HideEditButton = true;
                    HideOpenBidButton = true;
                    HideStartBidEvaluationButton = true;
                    break;
            }
        }

        public async Task<IActionResult> OnPostOpenBid(Guid id)
        {
            Bid = await _context.Bid.Include(b => b.Procurement).FirstOrDefaultAsync(b => b.Id == id);
            if (Bid != null && Bid.Status == BidStatus.RECEIVED.ToString())
            {
                Bid.Status = BidStatus.OPENED.ToString();
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Bid.Id, procurementid = Bid.Procurement.Id });
        }

        public async Task<IActionResult> OnPostStartBidEvaluation(Guid id)
        {
            Bid = await _context.Bid.Include(b => b.Procurement).FirstOrDefaultAsync(b => b.Id == id);
            if (Bid != null && Bid.Status == BidStatus.OPENED.ToString())
            {
                Bid.Status = BidStatus.UNDER_EVALUATION.ToString();
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Bid.Id, procurementid = Bid.Procurement.Id });
        }

        public async Task<IActionResult> OnPostCloseBidEvaluation(Guid id)
        {
            Bid = await _context.Bid.Include(b => b.Procurement).FirstOrDefaultAsync(b => b.Id == id);
            if (Bid != null && Bid.Status == BidStatus.UNDER_EVALUATION.ToString())
            {
                Bid.Status = BidStatus.EVALUATED.ToString();
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = Bid.Id, procurementid = Bid.Procurement.Id });
        }

        public async Task<IActionResult> OnPostAcceptBid(Guid id)
        {
            Bid = await _context.Bid.Include(b => b.Procurement).FirstOrDefaultAsync(b => b.Id == id);
            if (Bid != null && Bid.Status == BidStatus.EVALUATED.ToString())
            {
                Bid.Status = BidStatus.ACCEPTED.ToString();
                _context.SaveChanges();
            }

            return RedirectToPage("Details", new { id = id, procurementid = Bid.Procurement.Id });
        }
    }
}
