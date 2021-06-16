using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
    }
}
