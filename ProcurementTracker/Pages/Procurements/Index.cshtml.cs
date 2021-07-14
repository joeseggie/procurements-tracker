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

namespace ProcurementTracker.Pages.Procurements
{
    public class IndexModel : PageModel
    {
        private readonly ProcurementTracker.Data.ProcurementTrackerContext _context;

        public IndexModel(ProcurementTracker.Data.ProcurementTrackerContext context)
        {
            _context = context;
        }

        public IList<Procurement> Procurement { get;set; }

        public async Task OnGetAsync()
        {
            var connection = _context.Database.GetDbConnection().ConnectionString;
            Procurement = await _context.Procurement.ToListAsync();
        }

        public string GetRowColorCode(string procurementStatus)
        {
            string colorCode = procurementStatus switch
            {
                "NOT STARTED" => "table-dark",
                "ASSESSMENT OF MARKET PRICE" or "PROCUREMENT REQUISITIONS" or "CONFIRMATION OF AVAILABILITY OF FUNDS" or "REVIEW AND PREPARATION OF BIDDING DOCUMENTS" or "APPROVAL OF PROCUREMENT METHOD, BIDDING DOCUMENTS AND EVALUATION COMMITTEE" => "table-info",
                "ADVERTISING AND INVITATION OF BIDS" or "RECEIPT AND OPENING OF BIDS" or "EVALUATION OF BIDS" => "table-primary",
                "AWARD OF CONTRACT" or "BEB PRICE REASSESSMENT" or "ADMINISTRATIVE REVIEW" or "CONTRACT SIGNING" => "table-warning",
                "CONTRACT ISSUED" => "table-success",
                _ => "table-default",
            };
            return colorCode;
        }

        public string DisplayProcurementPlan(bool isPlanned)
        {
            return isPlanned ? "PROCUREMENT PLAN" : "BUDGET";
        }
    }
}
