using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared
{
    public class FundingSource
    {
        public FundingSource(string value)
        {
            Value = value;
        }

        public static FundingSource GOVERNMENT_OF_UGANDA { get { return new FundingSource("GOVERNMENT OF UGANDA"); } }

        public static FundingSource DONOR { get { return new FundingSource("DONOR"); } }

        public static FundingSource GOVERNMENT_OF_UGANDA_AND_DONOR { get { return new FundingSource("GOVERNMENT OF UGANDA AND DONOR"); } }

        public static FundingSource INTERNALLY_GENERATED_FUNDS { get { return new FundingSource("INTERNALLY GENERATED FUNDS"); } }

        public string Value { get; private set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
