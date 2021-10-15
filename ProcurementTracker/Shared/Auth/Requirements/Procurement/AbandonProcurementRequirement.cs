using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Procurement
{
    public class AbandonProcurementRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public AbandonProcurementRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}