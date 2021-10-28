using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using ProcurementTracker.Shared.Auth.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared.Auth.Handlers
{
    public class ActionAuthorizationHandler
    {
        public UserManager<ApplicationUser>? UserManager;
        public ProcurementTrackerContext? DbContext;

        private List<Guid?>? UserRoleIds = new List<Guid?>();

        public async Task<bool> CanPerformAction<T>(ClaimsPrincipal principalUser, IAuthorizationRequirement? requirement, string applicationAction) where T : BaseRequirement
        {
            bool canPerformAction = false;

            if (requirement is not T actionType || UserManager is null || DbContext is null)
                return canPerformAction;

            if (this.UserManager is not null && DbContext is not null)
            {
                ApplicationUser user = await UserManager.GetUserAsync(principalUser);

                if (user is not null)
                {
                    var userRoles = await DbContext.UserRoles.Where(r => r.UserId == user.Id).ToListAsync();
                    userRoles.ForEach(x => ExtractUserRoleIds(x.RoleId));

                    if (UserRoleIds is not null)
                    {
                        var roleApplicationActionsQuery = DbContext.RoleApplicationActions?.Include(a => a.ApplicationAction)
                                                                                            .Where(a => UserRoleIds.Contains(a.RoleId));
                        if (roleApplicationActionsQuery is not null)
                        {
                            var roleApplicationActions = await roleApplicationActionsQuery.ToListAsync();
                            canPerformAction = roleApplicationActions
                                                    .Any(a => a.ApplicationAction?.Action == applicationAction) &&
                                                              actionType.IsAuthorized;
                        }
                    }
                }
            }

            return canPerformAction;
        }

        private void ExtractUserRoleIds(string roleId)
        {
            if (!string.IsNullOrEmpty(roleId))
            {
                UserRoleIds?.Clear();
                UserRoleIds?.Add(Guid.Parse(roleId));
            }
        }
    }
}
