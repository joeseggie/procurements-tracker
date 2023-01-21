using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;

namespace ProcurementTracker.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public List<ProcurementOfficerAssignment> ProcurementOfficerAssignments { get; set; }
    }
}