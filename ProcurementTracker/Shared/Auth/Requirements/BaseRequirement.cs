using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements
{
    public class BaseRequirement : IAuthorizationRequirement
    {
        public bool IsAuthorized { get; protected set; }
    }
}
