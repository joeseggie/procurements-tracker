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

        public static ProcurementMethod MICRO_PROCUREMENT { get { return new ProcurementMethod("MICRO PROCUREMENT"); } }

        public static ProcurementMethod FRAMEWORK_SPECIAL_CONTRACTS { get { return new ProcurementMethod("FRAMEWORK AND SPECIAL CONTRACTS"); } }

        public static ProcurementMethod DIRECT_PROCUREMENT { get { return new ProcurementMethod("DIRECT PROCUREMENT"); } }

        public static ProcurementMethod REQUEST_FOR_QUOTATIONS_PROPOSALS { get { return new ProcurementMethod("REQUEST FOR QUOTATIONS OR PROPOSALS"); } }

        public static ProcurementMethod SELECTIVE_NATIONAL_BIDDING { get { return new ProcurementMethod("SELECTIVE NATIONAL BIDDING"); } }

        public static ProcurementMethod SELECTIVE_INTERNATIONAL_BIDDING { get { return new ProcurementMethod("SELECTIVE INTERNATIONAL BIDDING"); } }

        public static ProcurementMethod RESTRICTIVE_DOMESTIC_BIDDING { get { return new ProcurementMethod("RESTRICTIVE DOMESTIC BIDDING"); } }

        public static ProcurementMethod RESTRICTIVE_INTERNATIONAL_BIDDING { get { return new ProcurementMethod("RESTRICTIVE INTERNATIONAL BIDDING"); } }

        public static ProcurementMethod OPEN_DOMESTIC_BIDDING { get { return new ProcurementMethod("OPEN DOMESTIC BIDDING"); } }

        public static ProcurementMethod OPEN_INTERNATIONAL_BIDDING { get { return new ProcurementMethod("OPEN INTERNATIONAL BIDDING"); } }

        public static ProcurementMethod EXPRESSION_OF_INTEREST { get { return new ProcurementMethod("EXPRESSION OF INTEREST"); } }

        public static ProcurementMethod SHORTLISTING_OF_CONSULTANTS_WITHOUT_EXPRESSION_OF_INTEREST { get { return new ProcurementMethod("SHORTLISTING OF CONSULTANTS WITHOUT EXPRESSION OF INTEREST"); } }

        public static ProcurementMethod SINGLE_SOURCE_CONSULTANTS { get { return new ProcurementMethod("SINGLE SOURCE CONSULTANTS"); } }

        public static ProcurementMethod OPEN_NATIONAL_BIDDING { get { return new ProcurementMethod("OPEN NATIONAL BIDDING"); } }

        public static ProcurementMethod SPECIAL_METHOD { get { return new ProcurementMethod("SPECIAL METHOD"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
