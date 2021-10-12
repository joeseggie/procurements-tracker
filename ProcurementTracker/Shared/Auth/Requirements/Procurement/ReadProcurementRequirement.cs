using Microsoft.AspNetCore.Authorization;

namespace ProcurementTracker.Shared.Auth.Requirements.Procurement
{
    public class ReadProcurementRequirement : IAuthorizationRequirement
    {
        public bool CanReadProcurement { get; }

        public ReadProcurementRequirement(bool canReadProcurement)
        {
            CanReadProcurement = canReadProcurement;
        }
    }
}