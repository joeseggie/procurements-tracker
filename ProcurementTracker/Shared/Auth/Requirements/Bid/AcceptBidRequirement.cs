using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Bid
{
    public class AcceptBidRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public AcceptBidRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}
