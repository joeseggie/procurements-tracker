using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Procurement
{
    public class CreateProcurementRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public CreateProcurementRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}