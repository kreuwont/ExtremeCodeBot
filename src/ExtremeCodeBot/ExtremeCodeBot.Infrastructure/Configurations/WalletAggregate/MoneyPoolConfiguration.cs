using ExtremeCodeBot.Domain.Aggregates.WalletAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.WalletAggregate
{
    public class MoneyPoolConfiguration : IEntityTypeConfiguration<MoneyPool>
    {
        public void Configure(EntityTypeBuilder<MoneyPool> builder)
        {
            builder.ToTable("money_pool").HasKey(x => x.Id).HasName("id");

            builder.HasOne(x => x.Pool)
                .WithMany(x => x.MoneyPools)
                .HasForeignKey("pool_id");

            builder.Property(x => x.CurrencyValue).IsRequired().HasColumnName("currency_value");
            builder.Property(x => x.LockTime).IsRequired().HasColumnName("lock_time");
            builder.Property(x => x.UnlockTime).IsRequired().HasColumnName("unlock_time");
        }
    }
}