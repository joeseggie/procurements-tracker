using Microsoft.AspNetCore.Identity;
using ProcurementTracker.Models;
using System;
using System.Threading.Tasks;

namespace ProcurementTracker.Shared.Extensions
{
    public static class UserManagerExtensions
    {
        public static string? GetFirstNameAsync(this UserManager<ApplicationUser> userManager, ApplicationUser? user) => throw new NotImplementedException();
        public static string? GetLastNameAsync(this UserManager<ApplicationUser> userManager, ApplicationUser? user) => throw new NotImplementedException();
        public static Task<IdentityResult> SetFirstNameAsync(this UserManager<ApplicationUser> userManager, ApplicationUser? user) => throw new NotImplementedException();
        public static Task<IdentityResult> SetLastNameAsync(this UserManager<ApplicationUser> userManager, ApplicationUser? user) => throw new NotImplementedException();
    }
}
