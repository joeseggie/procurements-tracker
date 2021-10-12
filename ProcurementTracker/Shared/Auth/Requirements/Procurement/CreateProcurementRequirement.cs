using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Procurement
{
    public class CreateProcurementRequirement : IAuthorizationRequirement
    {
        public bool CanCreateProcurement { get; }

        public CreateProcurementRequirement(bool canCreateProcurement)
        {
            CanCreateProcurement = canCreateProcurement;
        }
    }
}