using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data.EntityTypeConfigurations;
using ProcurementTracker.Models;

namespace ProcurementTracker.Data
{
    public class ProcurementTrackerContext : IdentityDbContext<ApplicationUser>
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
            new ProcurementEntityTypeConfiguration().Configure(modelBuilder.Entity<Procurement>());
        }
    }
}
