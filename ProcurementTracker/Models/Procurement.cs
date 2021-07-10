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
        public decimal EstimatedAmount { get; set; }

        [Display(Name = "Procurement Method")]
        public string ProcurementMethod { get; set; }

        public string Status { get; set; }

        public int Quantity { get; set; }

        public string Department { get; set; }

        [Display(Name = "Procurement Type")]
        public string ProcurementType { get; set; }

        [Display(Name = "Exchange Rate")]
        public decimal ExchangeRate { get; set; }

        public string Currency { get; set; }

        public string FundingSource { get; set; }

        public DateTime AccountingApprovalDate { get; set; }

        public DateTime CCApprovalDate { get; set; }

        public DateTime CCSABDApprovalDate { get; set; }

        public DateTime PPQNoticeDate { get; set; }

        public DateTime PQPSClosingDate { get; set; }

        public DateTime EOIInvitationDate { get; set; }

        public DateTime EOIClosingDate { get; set; }

        public DateTime EOIShortlistApprovalDate { get; set; }

        public DateTime EOINotificationDate { get; set; }

        public DateTime BidInvitationDate { get; set; }

        public DateTime BidClosingDate { get; set; }

        public DateTime SERCCDate { get; set; }

        public DateTime AERCCDate { get; set; }

        public DateTime NegotiationDate { get; set; }

        public DateTime ANRCCDate { get; set; }

        public DateTime BEBNoticeDate { get; set; }

        public List<Bid> Bids { get; set; }
    }
}
