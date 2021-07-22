using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Models
{
    public class Procurement
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Estimated Amount")]
        public decimal EstimatedAmount { get; set; }

        [Display(Name = "Procurement Method")]
        public string ProcurementMethod { get; set; }

        public string Status { get; set; }

        public int Quantity { get; set; }

        public string Department { get; set; }

        [Display(Name = "Procurement Type")]
        public string ProcurementType { get; set; }

        [Display(Name = "Exchange Rate")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ExchangeRate { get; set; }

        public string Currency { get; set; }

        [Display(Name = "Source of Funding")]
        public string FundingSource { get; set; }

        [Display(Name = "Accounting Officers Approval Date")]
        public DateTime? AccountingApprovalDate { get; set; }

        [Display(Name = "Contracts Committee Approval Date")]
        public DateTime? CCApprovalDate { get; set; }

        [Display(Name = "Contracts Committee Approval of Shortlists & Bidding Documents Date")]
        public DateTime? CCSABDApprovalDate { get; set; }

        [Display(Name = "Publication of Pre-Qualification Notice Date")]
        public DateTime? PPQNoticeDate { get; set; }

        [Display(Name = "Closing Date of Pre-Qualification Proposal Submission")]
        public DateTime? PQPSClosingDate { get; set; }

        [Display(Name = "Invitation of Expressions of Interest Date")]
        public DateTime? EOIInvitationDate { get; set; }

        [Display(Name = "Closing Date")]
        public DateTime? EOIClosingDate { get; set; }

        [Display(Name = "Approval of Shortlist Date")]
        public DateTime? EOIShortlistApprovalDate { get; set; }

        [Display(Name = "Notification Date")]
        public DateTime? EOINotificationDate { get; set; }

        [Display(Name = "Bid Invitation Date")]
        public DateTime? BidInvitationDate { get; set; }

        [Display(Name = "Bid Closing Date")]
        public DateTime? BidClosingDate { get; set; }

        [Display(Name = "Submission of Evaluation Report to CC Date")]
        public DateTime? SERCCDate { get; set; }

        [Display(Name = "Approval of Evaluation Reports by Contracts Committee Date")]
        public DateTime? AERCCDate { get; set; }

        [Display(Name = "Negotiation Date")]
        public DateTime? NegotiationDate { get; set; }

        [Display(Name = "Approval of Negotiations Report Contracts Date")]
        public DateTime? ANRCCDate { get; set; }

        [Display(Name = "Best Evaluated Bidder Notice Date")]
        public DateTime? BEBNoticeDate { get; set; }

        [Display(Name = "Plan")]
        public bool IsPlanned { get; set; }

        public List<Bid> Bids { get; set; }

        public string StatusColorCode
        {
            get
            {
                string colorCode = Status switch
                {
                    "NOT STARTED" => "secondary",
                    "ABANDONED" => "dark",
                    "ASSESSMENT OF MARKET PRICE" or "PROCUREMENT REQUISITIONS" or "CONFIRMATION OF AVAILABILITY OF FUNDS" or "REVIEW AND PREPARATION OF BIDDING DOCUMENTS" or "APPROVAL OF PROCUREMENT METHOD, BIDDING DOCUMENTS AND EVALUATION COMMITTEE" => "info",
                    "ADVERTISING AND INVITATION OF BIDS" or "RECEIPT AND OPENING OF BIDS" or "EVALUATION OF BIDS" => "primary",
                    "AWARD OF CONTRACT" or "BEB PRICE REASSESSMENT" or "ADMINISTRATIVE REVIEW" or "CONTRACT SIGNING" => "warning",
                    "CONTRACT ISSUED" => "success",
                    _ => "default",
                };
                return colorCode;
            }
        }
    }
}
