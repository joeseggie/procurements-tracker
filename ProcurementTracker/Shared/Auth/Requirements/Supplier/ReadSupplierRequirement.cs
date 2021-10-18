using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Supplier
{
    public class ReadSupplierRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public ReadSupplierRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}
