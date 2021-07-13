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

        public static ProcurementStatus NOT_STARTED { get { return new ProcurementStatus("NOT STARTED"); } }

        public static ProcurementStatus CONTRACT_SIGNING { get { return new ProcurementStatus("CONTRACT SIGNING"); } }

        public static ProcurementStatus ABANDONED { get { return new ProcurementStatus("ABANDONED"); } }

        public static ProcurementStatus CONTRACT_ISSUED { get { return new ProcurementStatus("CONTRACT ISSUED"); } }

        public static ProcurementStatus MARKET_PRICE_ASSESSMENT { get { return new ProcurementStatus("ASSESSMENT OF MARKET PRICE"); } }

        public static ProcurementStatus PROCUREMENT_REQUISITIONS { get { return new ProcurementStatus("PROCUREMENT REQUISITIONS"); } }

        public static ProcurementStatus FUNDS_AVAILABILITY_CONFIRMATION { get { return new ProcurementStatus("CONFIRMATION OF AVAILABILITY OF FUNDS"); } }

        public static ProcurementStatus BIDDING_DOCUMENTS_PREPARATION { get { return new ProcurementStatus("REVIEW AND PREPARATION OF BIDDING DOCUMENTS"); } }

        public static ProcurementStatus PMBDEV_APPROVAL { get { return new ProcurementStatus("APPROVAL OF PROCUREMENT METHOD, BIDDING DOCUMENTS AND EVALUATION COMMITTEE"); } }

        public static ProcurementStatus BIDS_INVITATION { get { return new ProcurementStatus("ADVERTISING AND INVITATION OF BIDS"); } }

        public static ProcurementStatus BIDS_RECEIPT_AND_OPENING { get { return new ProcurementStatus("RECEIPT AND OPENING OF BIDS"); } }

        public static ProcurementStatus BIDS_EVALUATION { get { return new ProcurementStatus("EVALUATION OF BIDS"); } }

        public static ProcurementStatus CONTRACT_AWARD { get { return new ProcurementStatus("AWARD OF CONTRACT"); } }

        public static ProcurementStatus BEB_PRICE_REVIEW { get { return new ProcurementStatus("BEB PRICE REASSESSMENT"); } }

        public static ProcurementStatus ADMINISTRATIVE_REVIEW { get { return new ProcurementStatus("ADMINISTRATIVE REVIEW"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
