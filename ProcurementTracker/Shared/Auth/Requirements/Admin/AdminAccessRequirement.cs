using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Admin
{
	public class AdminAccessRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public AdminAccessRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}
