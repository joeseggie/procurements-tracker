using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared
{
    public class ProcurementMethod
    {
        public ProcurementMethod(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static ProcurementMethod DOMESTIC_OPEN_BIDDING { get { return new ProcurementMethod("DOMESTIC OPEN BIDDING"); } }

        public static ProcurementMethod INTERNATIONAL_OPEN_BIDDING { get { return new ProcurementMethod("INTERNATIONAL OPEN BIDDING"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
