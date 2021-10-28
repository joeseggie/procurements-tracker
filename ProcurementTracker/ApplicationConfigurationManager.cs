using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker
{
    public static class ApplicationConfigurationManager
    {
        public static void LoadEnvironmentVariables(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }

        public static async void InitializeDatabase(ProcurementTrackerContext? context)
        {
            if (context == null)
                return;

            context.Database.Migrate();

            await SeedApplicationActionsAsync(context);
            Guid? adminRoleId = await SeedAdminRolesAsync(context);
            Guid? adminUserId = await SeedAdminUserAsync(context);
            await SeedAdminUserRolesAsync(context, adminUserId, adminRoleId);
            await SeedAdminUserRoleActions(context, adminRoleId);
        }

        private static async Task SeedAdminUserRoleActions(ProcurementTrackerContext context, Guid? adminRoleId)
        {
            var adminApplicationActions = GetAdminApplicationActions();

            foreach (var (action, area, description) in adminApplicationActions)
            {
                bool isActionAssigned = await context.RoleApplicationActions.AnyAsync(a => a.ApplicationAction.Action == action);

                if (isActionAssigned is false)
                {
                    var adminAction = await context.ApplicationActions.FirstOrDefaultAsync(a => a.Action == action);
                    if (adminAction is not null)
                    {
                        await context.RoleApplicationActions!.AddAsync(new RoleApplicationAction
                        {
                            RoleId = adminRoleId,
                            ApplicationActionId = adminAction.Id
                        });
                    }
                }
            }

            await context.SaveChangesAsync();
        }

        private static System.Collections.Generic.List<(string action, string area, string description)> GetAdminApplicationActions()
        {
            return ApplicationConfigurationData
                        .GetApplicationActions()
                        .Where(a => a.area == "USERS" || a.area == "ROLES" || a.area == "ACTIONS")
                        .ToList();
        }

        private static async Task SeedAdminUserRolesAsync(ProcurementTrackerContext context, Guid? adminUserId, Guid? adminRoleId)
        {
            if (adminUserId.HasValue && adminRoleId.HasValue)
            {
                var adminUserRole = await context.UserRoles.FirstOrDefaultAsync(userRole => userRole.UserId == adminUserId.Value.ToString() &&
                                                                                            userRole.RoleId == adminRoleId.Value.ToString());
                if (adminUserRole == null)
                {
                    IdentityUserRole<string> userRole = new()
                    {
                        RoleId = adminRoleId.Value.ToString(),
                        UserId = adminUserId.Value.ToString(),
                    };

                    await context.UserRoles.AddAsync(userRole);
                    await context.SaveChangesAsync();
                }
            }

        }

        private static async Task<Guid?> SeedAdminUserAsync(ProcurementTrackerContext context)
        {
            var adminUserCredentials = ApplicationConfigurationData.GetAdminCredentials();

            if (adminUserCredentials.username is null || adminUserCredentials.email is null || adminUserCredentials.password is null)
                return null;

            Guid adminUserId;

            var adminUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == adminUserCredentials.username && u.Email == adminUserCredentials.email);
            if (adminUser == null)
            {
                adminUserId = Guid.NewGuid();

                ApplicationUser user = new()
                {
                    Id = adminUserId.ToString(),
                    UserName = adminUserCredentials.username,
                    Email = adminUserCredentials.email,
                    Firstname = adminUserCredentials.firstname,
                    Lastname = adminUserCredentials.lastname,
                    NormalizedEmail = adminUserCredentials.email.ToUpper(),
                    NormalizedUserName = adminUserCredentials.username.ToUpper(),
                };

                var passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, adminUserCredentials.password);

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
            else
                adminUserId = Guid.Parse(adminUser.Id);

            return adminUserId;
        }

        private static async Task<Guid?> SeedAdminRolesAsync(ProcurementTrackerContext context)
        {
            var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == RoleName.ADMIN);

            Guid id;

            if (adminRole != null)
                id = Guid.Parse(adminRole.Id);
            else
            {
                id = Guid.NewGuid();

                IdentityRole role = new()
                {
                    Id = id.ToString(),
                    Name = RoleName.ADMIN,
                    NormalizedName = RoleName.ADMIN.ToUpper()
                };
                await context.Roles.AddAsync(role);
                await context.SaveChangesAsync();
            }
            return id;
        }

        private static async Task SeedApplicationActionsAsync(ProcurementTrackerContext context)
        {
            var actions = ApplicationConfigurationData.GetApplicationActions();
            foreach (var action in actions)
            {
                await AddActionToDatabaseAsync(context, action);
            }
        }

        private static async Task AddActionToDatabaseAsync(ProcurementTrackerContext context, (string action, string area, string description) actionToAdd)
        {
            if (await context.ApplicationActions.AnyAsync(a => a.Action == actionToAdd.action)) return;

            ApplicationAction appAction = new()
            {
                Action = actionToAdd.action,
                Description = actionToAdd.description,
                Area = actionToAdd.area
            };

            await context.ApplicationActions!.AddAsync(appAction);
            await context.SaveChangesAsync();
        }
    }
}
