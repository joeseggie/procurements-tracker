using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared
{
    public class ProcurementType
    {
        public ProcurementType(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static ProcurementType SUPPLIES { get { return new ProcurementType("SUPPLIES"); } }

        public static ProcurementType WORKS { get { return new ProcurementType("WORKS"); } }

        public static ProcurementType SERVICES { get { return new ProcurementType("SERVICES"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
