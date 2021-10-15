using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Procurement
{
    public class ReadProcurementRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public ReadProcurementRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}