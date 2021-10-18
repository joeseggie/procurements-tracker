using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Supplier
{
    public class EditSupplierRequirement : BaseRequirement, IAuthorizationRequirement
    {
        public EditSupplierRequirement(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}
