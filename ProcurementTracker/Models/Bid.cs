using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Valid Period (Days)")]
        public int ValidPeriod { get; set; }
        public Supplier Supplier { get; set; }
        public Procurement Procurement { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Quoted Fee")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = false)]
        public decimal QuotedFee { get; set; }

        public string RejectionReason { get; set; }

        public string StatusColorCode
        {
            get
            {
                string colorCode = Status switch
                {
                    "RECEIVED" => "secondary",
                    "OPENED" => "info",
                    "UNDER EVALUATION" => "primary",
                    "EVALUATED" => "warning",
                    "ACCEPTED" => "success",
                    "REJECTED" => "danger",
                    _ => "default",
                };
                return colorCode;
            }
        }
    }
}
