using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Bid
{
    public class EditBidRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public EditBidRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}
