using ExtremeCodeBot.Domain.Aggregates.WalletAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.WalletAggregate
{
    public class MoneyPoolConfiguration : IEntityTypeConfiguration<MoneyPool>
    {
        public void Configure(EntityTypeBuilder<MoneyPool> builder)
        {
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.CurrencyValue).HasColumnName("currency_value");
            builder.Property(x => x.LockTime).HasColumnName("lock_time");
            builder.Property(x => x.UnlockTime).HasColumnName("unlock_time");
        }
    }
}