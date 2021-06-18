using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcurementTracker.Models;

namespace ProcurementTracker.Data.EntityTypeConfigurations
{
    public class BidEntityTypeConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.HasOne(b => b.Supplier)
                .WithMany(s => s.Bids);

            builder.HasOne(b => b.Procurement)
                .WithMany(p => p.Bids);
        }
    }
}
