using System;

namespace ProcurementTracker.Models
{
    public class RoleApplicationAction
    {
        public Guid? Id { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? ApplicationActionId { get; set; }

        public ApplicationAction? ApplicationAction { get; set; }
    }
}