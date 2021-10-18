using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Supplier
{
    public class CreateSupplierRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public CreateSupplierRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}
