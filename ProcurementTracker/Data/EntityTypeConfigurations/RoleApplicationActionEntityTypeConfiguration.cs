using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Models;

namespace ProcurementTracker.Data.EntityTypeConfigurations
{
    public class RoleApplicationActionEntityTypeConfiguration : IEntityTypeConfiguration<RoleApplicationAction>
    {
        public void Configure(EntityTypeBuilder<RoleApplicationAction> builder)
        {
            
            builder.HasOne(x => x.ApplicationAction)
                   .WithMany( x => x!.RoleApplicationActions)
                   .HasForeignKey(x => x.ApplicationActionId);
        }
    }
}