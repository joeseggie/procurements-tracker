﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Models
{
    public class Procurement
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public string ProcurementMethod { get; set; }
        public string Status { get; set; }

        public List<Bid> Bids { get; set; }
    }
}
