using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared
{
    public class Currency
    {
        public string Value { get; private set; }

        public Currency(string value)
        {
            Value = value;
        }

        public static Currency UGANDA_SHILLING { get { return new Currency("UGX"); } }

        public static Currency POUND_STERLING { get { return new Currency("POUND STERLING"); } }

        public static Currency EURO { get { return new Currency("EURO"); } }

        public static Currency JAPANESE_YEN { get { return new Currency("JPY"); } }

        public static Currency US_DOLLAR { get { return new Currency("USD"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
