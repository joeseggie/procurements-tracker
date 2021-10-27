using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using ProcurementTracker.Shared.Auth.Requirements.Admin;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared.Auth.Handlers
{
	public class AdminAccessHandler : IAuthorizationHandler
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ProcurementTrackerContext _dbContext;

        public AdminAccessHandler(UserManager<ApplicationUser> userManager, ProcurementTrackerContext dbContext)
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
                if (requirement is AdminAccessRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "add_user")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "view_user")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "edit_user")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "disable_user")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "list_users")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "add_role")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "edit_role")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "view_role")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "list_roles")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "view_action")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<AdminAccessRequirement>(context.User, requirement, "list_actions")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
