using ExtremeCodeBot.Domain.Aggregates.PoolAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.PoolAggregate
{
    public class PoolConfiguration : IEntityTypeConfiguration<Pool>
    {
        public void Configure(EntityTypeBuilder<Pool> builder)
        {
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.CloseTime).HasColumnName("close_time");
            builder.Property(x => x.CreatedTime).HasColumnName("created_time");
            builder.Property(x => x.IncreasePercent).HasColumnName("increase_percent");
            builder.Property(x => x.IsActive).HasColumnName("is_active");
            builder.Property(x => x.LockTime).HasColumnName("lock_time");
            builder.Property(x => x.OpenTime).HasColumnName("open_time");
        }
    }
}