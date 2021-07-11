using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared
{
    public class ProcurementStatus
    {
        private ProcurementStatus(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static ProcurementStatus NOT_STARTED { get { return new ProcurementStatus("Not Started"); } }

        public static ProcurementStatus CONTRACT_SIGNING { get { return new ProcurementStatus("Contract Signing"); } }

        public static ProcurementStatus ABANDONED { get { return new ProcurementStatus("Abandoned"); } }

        public static ProcurementStatus CONTRACT_ISSUED { get { return new ProcurementStatus("Contract Issued"); } }

        public static ProcurementStatus MARKET_PRICE_ASSESSMENT { get { return new ProcurementStatus("Assessment of Market Price"); } }

        public static ProcurementStatus PROCUREMENT_REQUISITIONS { get { return new ProcurementStatus("Procurement Requisitions"); } }

        public static ProcurementStatus FUNDS_AVAILABILITY_CONFIRMATION { get { return new ProcurementStatus("Confirmation of Availability of Funds"); } }

        public static ProcurementStatus BIDDING_DOCUMENTS_PREPARATION { get { return new ProcurementStatus("Review and Preparation of Bidding Documents"); } }

        public static ProcurementStatus PMBDEV_APPROVAL { get { return new ProcurementStatus("Approval of Procurement Method, Bidding Documents and Evaluation Committee"); } }

        public static ProcurementStatus BIDS_INVITATION { get { return new ProcurementStatus("Advertising and Invitation of Bids"); } }

        public static ProcurementStatus BIDS_RECEIPT_AND_OPENING { get { return new ProcurementStatus("Receipt and Opening of Bids"); } }

        public static ProcurementStatus BIDS_EVALUATION { get { return new ProcurementStatus("Evaluation of Bids"); } }

        public static ProcurementStatus CONTRACT_AWARD { get { return new ProcurementStatus("Award of Contract"); } }

        public static ProcurementStatus BEB_PRICE_REVIEW { get { return new ProcurementStatus("BEB Price Reassessment"); } }

        public static ProcurementStatus ADMINISTRATIVE_REVIEW { get { return new ProcurementStatus("Administrative Review"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
