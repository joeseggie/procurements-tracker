using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared
{
    public class BidStatus
    {
        public BidStatus(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static BidStatus RECEIVED { get { return new BidStatus("RECEIVED"); } }

        public static BidStatus OPENED { get { return new BidStatus("OPENED"); } }

        public static BidStatus UNDER_EVALUATION { get { return new BidStatus("UNDER EVALUATION"); } }

        public static BidStatus EVALUATED { get { return new BidStatus("EVALUATED"); } }

        public static BidStatus ACCEPTED { get { return new BidStatus("ACCEPTED"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
