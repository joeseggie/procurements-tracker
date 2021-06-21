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

        public static ProcurementStatus NOTSTARTED { get { return new ProcurementStatus("NOT STARTED"); } }

        public static ProcurementStatus INPROGRESS { get { return new ProcurementStatus("IN PROGRESS"); } }

        public static ProcurementStatus ABANDONED { get { return new ProcurementStatus("ABANDONED"); } }

        public static ProcurementStatus CLOSED { get { return new ProcurementStatus("CLOSED"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
