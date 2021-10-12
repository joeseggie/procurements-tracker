using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Procurement
{
    public class EditProcurementRequirement : IAuthorizationRequirement
    {
        public bool CanEditRequirement { get; }

        public EditProcurementRequirement(bool canEditProcurement)
        {
            CanEditRequirement = canEditProcurement;
        }
    }
}