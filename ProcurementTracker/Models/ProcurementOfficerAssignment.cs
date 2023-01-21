using System;

namespace ProcurementTracker.Models
{
    public class ProcurementOfficerAssignment
    {
        public Guid? Id { get; set; }

        public Procurement? Procurement { get; set; }

        public ApplicationUser? Officer { get; set; }

        public DateTime? DateAssigned { get; set; }
    }
}
