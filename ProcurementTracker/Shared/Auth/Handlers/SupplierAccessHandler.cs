using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using ProcurementTracker.Shared.Auth.Requirements.Supplier;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared.Auth.Handlers
{
    public class SupplierAccessHandler : IAuthorizationHandler
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ProcurementTrackerContext _dbContext;

        public SupplierAccessHandler(UserManager<ApplicationUser> userManager, ProcurementTrackerContext dbContext)
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
                if (requirement is ReadSupplierRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<ReadSupplierRequirement>(context.User, requirement, "list_suppliers")).Result ||
                        (actionAuthorizationHandler.CanPerformAction<ReadSupplierRequirement>(context.User, requirement, "view_supplier")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is CreateSupplierRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<CreateSupplierRequirement>(context.User, requirement, "add_supplier")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is EditSupplierRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<EditSupplierRequirement>(context.User, requirement, "edit_supplier")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
