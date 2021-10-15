using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Bid
{
    public class CreateBidRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public CreateBidRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}
