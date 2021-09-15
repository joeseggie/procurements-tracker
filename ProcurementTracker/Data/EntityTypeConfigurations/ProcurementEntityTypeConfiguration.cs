using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Models;

namespace ProcurementTracker.Data.EntityTypeConfigurations
{
    class ProcurementEntityTypeConfiguration : IEntityTypeConfiguration<Procurement>
    {
        public void Configure(EntityTypeBuilder<Procurement> builder)
        {
            builder.Property(p => p.IsPlanned)
                   .HasDefaultValue(false);
        }
    }
}