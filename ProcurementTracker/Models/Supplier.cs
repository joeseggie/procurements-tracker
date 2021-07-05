using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Contact { get; set; }

        [Display(Name = "Service Provider")]
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Bid> Bids { get; set; }
    }
}
