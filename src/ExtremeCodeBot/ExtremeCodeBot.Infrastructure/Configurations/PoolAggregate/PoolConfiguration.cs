using ExtremeCodeBot.Domain.Aggregates.PoolAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.PoolAggregate
{
    public class PoolConfiguration : IEntityTypeConfiguration<Pool>
    {
        public void Configure(EntityTypeBuilder<Pool> builder)
        {
            builder.ToTable("pool").HasKey(x => x.Id).HasName("id");

            builder.HasOne(x => x.Creator)
                .WithMany(x => x.Pools)
                .HasForeignKey("creator_id");

            builder.Property(x => x.Name).IsRequired().HasColumnName("name");
            builder.Property(x => x.CloseTime).HasColumnName("close_time");
            builder.Property(x => x.CreatedTime).IsRequired().HasColumnName("created_time");
            builder.Property(x => x.IncreasePercent).IsRequired().HasColumnName("increase_percent");
            builder.Property(x => x.IsActive).HasColumnName("is_active");
            builder.Property(x => x.LockTime).IsRequired().HasColumnName("lock_time");
            builder.Property(x => x.OpenTime).IsRequired().HasColumnName("open_time");
        }
    }
}