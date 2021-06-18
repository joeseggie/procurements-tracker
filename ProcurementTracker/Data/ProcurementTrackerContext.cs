using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Data.EntityTypeConfigurations;
using ProcurementTracker.Models;

namespace ProcurementTracker.Data
{
    public class ProcurementTrackerContext : DbContext
    {
        public ProcurementTrackerContext (DbContextOptions<ProcurementTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<ProcurementTracker.Models.Supplier> Supplier { get; set; }

        public DbSet<ProcurementTracker.Models.Bid> Bid { get; set; }

        public DbSet<ProcurementTracker.Models.Procurement> Procurement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BidEntityTypeConfiguration().Configure(modelBuilder.Entity<Bid>());
        }
    }
}
