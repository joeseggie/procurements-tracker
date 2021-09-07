using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data.EntityTypeConfigurations;
using ProcurementTracker.Models;

namespace ProcurementTracker.Data
{
    public class ProcurementTrackerContext : IdentityDbContext
    {
        public ProcurementTrackerContext(DbContextOptions<ProcurementTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Supplier>? Supplier { get; set; }

        public DbSet<Bid>? Bid { get; set; }

        public DbSet<Procurement>? Procurement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new BidEntityTypeConfiguration().Configure(modelBuilder.Entity<Bid>());

            //Guid adminRoleId = SeedAdminRoles(modelBuilder);
            //Guid adminUserId = SeedAdminUsers(modelBuilder);
            //SeedAdminUserRoles(modelBuilder, adminUserId, adminRoleId);
        }

        //private static Guid SeedAdminRoles(ModelBuilder modelBuilder)
        //{
        //    Guid id = Guid.NewGuid();
        //    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = id.ToString(), Name = RoleName.ADMIN });
        //    return id;
        //}

        //private static Guid SeedAdminUsers(ModelBuilder modelBuilder)
        //{
        //    Guid id = Guid.NewGuid();
        //    var defaultAdminUser = new DefaultAdminUser(Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_USERNAME"),
        //                                                Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_EMAIL"));

        //    var user = new IdentityUser
        //    {
        //        Id = id.ToString(),
        //        UserName = defaultAdminUser.Username,
        //        Email = defaultAdminUser.Email,
        //        EmailConfirmed = true
        //    };

        //    PasswordHasher<IdentityUser> passwordHasher = new();
        //    user.PasswordHash = passwordHasher.HashPassword(user, Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_PASSWORD"));

        //    modelBuilder.Entity<IdentityUser>().HasData(user);

        //    return id;
        //}

        //private static void SeedAdminUserRoles(ModelBuilder modelBuilder, Guid userId, Guid roleId)
        //{
        //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(new { UserId = userId.ToString(), RoleId = roleId.ToString() });
        //}
    }
}
