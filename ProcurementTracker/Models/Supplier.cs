using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
