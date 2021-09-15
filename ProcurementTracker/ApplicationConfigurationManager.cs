using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data;
using ProcurementTracker.Models;
using System;
using System.Collections.Generic;
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

            Guid? adminRoleId = await SeedAdminRolesAsync(context);
            Guid? adminUserId = await SeedAdminUserAsync(context);
            await SeedAdminUserRolesAsync(context, adminUserId, adminRoleId);
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
            string? username = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_USERNAME");
            string? email = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_EMAIL");
            string? password = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_PASSWORD");
            string? firstname = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_FIRSTNAME");
            string? lastname = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_LASTNAME");

            if (username is null || email is null || password is null)
                return null;

            Guid adminUserId;

            var adminUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Email == email);
            if (adminUser == null)
            {
                adminUserId = Guid.NewGuid();

                ApplicationUser user = new()
                {
                    Id = adminUserId.ToString(),
                    UserName = username,
                    Email = email,
                    Firstname = firstname,
                    Lastname = lastname,
                    NormalizedEmail = email.ToUpper(),
                    NormalizedUserName = username.ToUpper(),
                };

                var passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, password);

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
    }
}
