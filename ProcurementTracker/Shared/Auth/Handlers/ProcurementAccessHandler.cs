using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using ProcurementTracker.Shared.Auth.Requirements.Procurement;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared.Auth.Handlers
{
    public class ProcurementAccessHandler : IAuthorizationHandler
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ProcurementTrackerContext _dbContext;

        public ProcurementAccessHandler(UserManager<ApplicationUser> userManager, ProcurementTrackerContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            ActionAuthorizationHandler actionAuthorizationHandler = new()
            {
                UserManager = _userManager,
                DbContext = _dbContext
            };

            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
                if (requirement is ReadProcurementRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<ReadProcurementRequirement>(context.User, requirement, "list_procurements")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<ReadProcurementRequirement>(context.User, requirement, "list_unabandoned_procurements")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<ReadProcurementRequirement>(context.User, requirement, "list_abandoned_procurements")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<ReadProcurementRequirement>(context.User, requirement, "view_procurement_details")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is CreateProcurementRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<CreateProcurementRequirement>(context.User, requirement, "add_procurement")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is EditProcurementRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<EditProcurementRequirement>(context.User, requirement, "edit_procurement")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is AbandonProcurementRequirement)
                {
                    if((actionAuthorizationHandler.CanPerformAction<AbandonProcurementRequirement>(context.User, requirement, "abandon_procurement")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}