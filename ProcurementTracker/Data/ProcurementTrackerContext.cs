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

        public DbSet<Supplier>? Suppliers { get; set; }

        public DbSet<Bid>? Bids { get; set; }

        public DbSet<Procurement>? Procurements { get; set; }

        public DbSet<ApplicationAction>? ApplicationActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new BidEntityTypeConfiguration().Configure(modelBuilder.Entity<Bid>());
            new ProcurementEntityTypeConfiguration().Configure(modelBuilder.Entity<Procurement>());
        }
    }
}
