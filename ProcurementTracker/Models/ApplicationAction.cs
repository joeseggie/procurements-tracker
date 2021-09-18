using System;

namespace ProcurementTracker.Models
{
    public class ApplicationAction
    {
        public Guid Id { get; set; }

        public string? Action { get; set; }

        public string? Description { get; set; }

        public string? Area { get; set; }
    }
}