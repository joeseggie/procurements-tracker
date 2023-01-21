using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Models;

namespace ProcurementTracker.Data.EntityTypeConfigurations
{
    public class ProcurementOfficerAssignmentEntityTypeConfiguration : IEntityTypeConfiguration<ProcurementOfficerAssignment>
    {
        public void Configure(EntityTypeBuilder<ProcurementOfficerAssignment> builder)
        {
            builder.HasOne(entity => entity.Procurement)
                .WithMany(s => s.ProcurementOfficerAssignments);

            builder.HasOne(b => b.Officer)
                .WithMany(p => p.ProcurementOfficerAssignments);
        }
    }
}
