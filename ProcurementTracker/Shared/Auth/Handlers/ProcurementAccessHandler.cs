using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ProcurementTracker.Shared.Auth.Requirements.Procurement;
using Microsoft.AspNetCore.Identity;
using ProcurementTracker.Models;
using ProcurementTracker.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace ProcurementTracker.Shared.Auth.Handlers
{
    public class ProcurementAccessHandler : IAuthorizationHandler
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ProcurementTrackerContext _dbContext;
        private readonly ILogger<ProcurementAccessHandler> _logger;

        private List<Guid?>? UserRoleIds = new List<Guid?>();

        public ProcurementAccessHandler(UserManager<ApplicationUser> userManager,
                                         ProcurementTrackerContext dbContext,
                                         ILogger<ProcurementAccessHandler> logger)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
                if (requirement is ReadProcurementRequirement)
                {
                    if ((CanReadProcurement(context.User, requirement)).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is CreateProcurementRequirement)
                {
                    if ((CanCreateProcurement(context.User, requirement)).Result)
                    {
                        context.Succeed(requirement);
                    }
                }
            }

            return Task.CompletedTask;
        }

        private async Task<bool> CanCreateProcurement(ClaimsPrincipal principalUser, IAuthorizationRequirement? requirement)
        {
            bool canCreateProcurement = false;

            if (requirement is not CreateProcurementRequirement createProcurementRequirement)
                return canCreateProcurement;

            if (_userManager is not null && _dbContext is not null)
            {
                ApplicationUser user = await _userManager.GetUserAsync(principalUser);

                if (user is not null)
                {
                    var userRoles = await _dbContext.UserRoles.Where(r => r.UserId == user.Id).ToListAsync();
                    userRoles.ForEach(x => ExtractUserRoleIds(x.RoleId));

                    if (UserRoleIds is not null)
                    {
                        var roleApplicationActionsQuery = _dbContext.RoleApplicationActions?.Include(a => a.ApplicationAction)
                                                                                            .Where(a => UserRoleIds.Contains(a.RoleId));
                        if (roleApplicationActionsQuery is not null)
                        {
                            var roleApplicationActions = await roleApplicationActionsQuery.ToListAsync();
                            canCreateProcurement = roleApplicationActions
                                                    .Any(a => a.ApplicationAction?.Action == "add_procurement") &&
                                                              createProcurementRequirement.CanCreateProcurement;
                        }
                    }
                }
            }

            return canCreateProcurement;
        }

        private async Task<bool> CanReadProcurement(ClaimsPrincipal principalUser, IAuthorizationRequirement? requirement)
        {
            bool canReadProcurement = false;

            if (requirement is not ReadProcurementRequirement readProcurementRequirement)
                return canReadProcurement;

            if (_userManager is not null && _dbContext is not null)
            {
                ApplicationUser user = await _userManager.GetUserAsync(principalUser);

                if (user is not null)
                {
                    var userRoles = await _dbContext.UserRoles.Where(r => r.UserId == user.Id).ToListAsync();
                    userRoles.ForEach(x => ExtractUserRoleIds(x.RoleId));

                    if (UserRoleIds is not null)
                    {
                        var roleApplicationActionsQuery = _dbContext.RoleApplicationActions?.Include(a => a.ApplicationAction)
                                                                                            .Where(a => UserRoleIds.Contains(a.RoleId));
                        if (roleApplicationActionsQuery is not null)
                        {
                            var roleApplicationActions = await roleApplicationActionsQuery.ToListAsync();
                            canReadProcurement = roleApplicationActions
                                                    .Any(a => a.ApplicationAction?.Action == "list_procurements" ||
                                                              a.ApplicationAction?.Action == "list_unabandoned_procurements" ||
                                                              a.ApplicationAction?.Action == "list_abandoned_procurements" ||
                                                              a.ApplicationAction?.Action == "view_procurement_details") &&
                                                              readProcurementRequirement.CanReadProcurement;
                        }
                    } 
                }
            }

            return canReadProcurement;
        }

        private void ExtractUserRoleIds(string roleId)
        {
            if (!string.IsNullOrEmpty(roleId))
            {
                UserRoleIds?.Add(Guid.Parse(roleId));
            }
        }
    }
    //public class ProcurementAccessHandler : AuthorizationHandler<ReadProcurementRequirement>
    //{
    //    private readonly UserManager<ApplicationUser>? _userManager;
    //    private readonly ProcurementTrackerContext? _dbContext;
    //    private readonly ILogger<ProcurementAccessHandler> _logger;

    //    private List<Guid?>? UserRoleIds = new List<Guid?>();

    //    public ProcurementAccessHandler(UserManager<ApplicationUser> userManager, ProcurementTrackerContext dbContext, ILogger<ProcurementAccessHandler> logger)
    //    {
    //        _userManager = userManager;
    //        _dbContext = dbContext;
    //        _logger = logger;
    //    }

    //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ReadProcurementRequirement requirement)
    //    {
    //        if ((CanReadProcurement(context, requirement)).Result)
    //        {
    //            context.Succeed(requirement);
    //        }

    //        return Task.CompletedTask;
    //    }

    //    private async Task<bool> CanReadProcurement(AuthorizationHandlerContext context, ReadProcurementRequirement requirement)
    //    {
    //        bool canReadProcurement = false;

    //        if (_userManager is not null && _dbContext is not null)
    //        {
    //            ApplicationUser user = await _userManager.GetUserAsync(context.User);
    //            _logger.LogTrace($"User queried: {user.Firstname} {user.UserName}");

    //            var userRoles = await _dbContext.UserRoles.Where(r => r.UserId == user.Id).ToListAsync();
    //            userRoles.ForEach(x => ExtractUserRoleIds(x.RoleId));

    //            if (UserRoleIds is not null)
    //            {
    //                var roleApplicationActionsQuery = _dbContext.RoleApplicationActions?.Include(a => a.ApplicationAction)
    //                                                                                    .Where(a => UserRoleIds.Contains(a.RoleId));
    //                if (roleApplicationActionsQuery is not null)
    //                {
    //                    var roleApplicationActions = await roleApplicationActionsQuery.ToListAsync();
    //                    canReadProcurement = roleApplicationActions.Any(a => a.ApplicationAction?.Action == "list_procurements" ||
    //                                                                         a.ApplicationAction?.Action == "list_unabandoned_procurements" || 
    //                                                                         a.ApplicationAction?.Action == "list_abandoned_procurements") && requirement.CanReadProcurement;
    //                }
    //            }
    //        }

    //        return canReadProcurement;
    //    }

    //    private void ExtractUserRoleIds(string roleId)
    //    {
    //        if (!string.IsNullOrEmpty(roleId))
    //        {
    //            UserRoleIds?.Add(Guid.Parse(roleId));
    //        }
    //    }
    //}
}