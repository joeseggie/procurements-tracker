using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using ProcurementTracker.Shared.Auth.Requirements.Bid;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared.Auth.Handlers
{
    public class BidAccessHandler : IAuthorizationHandler
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ProcurementTrackerContext _dbContext;

        public BidAccessHandler(UserManager<ApplicationUser> userManager, ProcurementTrackerContext dbContext)
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
                if (requirement is ReadBidRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<ReadBidRequirement>(context.User, requirement, "list_bids")).Result || 
                        (actionAuthorizationHandler.CanPerformAction<ReadBidRequirement>(context.User, requirement, "view_bid")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is CreateBidRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<CreateBidRequirement>(context.User, requirement, "add_bid")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is EditBidRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<EditBidRequirement>(context.User, requirement, "edit_bid")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is AcceptBidRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<AcceptBidRequirement>(context.User, requirement, "accept_bid")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is RejectBidRequirement)
                {
                    if ((actionAuthorizationHandler.CanPerformAction<RejectBidRequirement>(context.User, requirement, "reject_bid")).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
