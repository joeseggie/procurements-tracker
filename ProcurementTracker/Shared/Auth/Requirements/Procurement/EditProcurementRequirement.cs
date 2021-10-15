using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Procurement
{
    public class EditProcurementRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public EditProcurementRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}