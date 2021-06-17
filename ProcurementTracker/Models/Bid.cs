using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Models
{
    public class Bid
    {
        public Guid Id { get; set; }
        public string Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Submitted { get; set; }

        public int ValidPeriod { get; set; }
        public Supplier Supplier { get; set; }
        public Procurement Procurement { get; set; }
    }
}
