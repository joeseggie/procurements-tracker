using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Bid
{
    public class ReadBidRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public ReadBidRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}
