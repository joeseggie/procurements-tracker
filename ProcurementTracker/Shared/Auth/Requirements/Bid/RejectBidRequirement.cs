using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Bid
{
    public class RejectBidRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public RejectBidRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}
