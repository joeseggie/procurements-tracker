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

        public static BidStatus OPEN { get { return new BidStatus("OPEN"); } }

        public static BidStatus UNDER_EVALUATION { get { return new BidStatus("UNDER EVALUATION"); } }

        public static BidStatus EVALUATED { get { return new BidStatus("EVALUATED"); } }

        public static BidStatus ACCEPTED { get { return new BidStatus("ACCEPTED"); } }

        public static BidStatus EXPIRED { get { return new BidStatus("EXPIRED"); } }

        public static BidStatus EXPIRING { get { return new BidStatus("EXPIRING"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
