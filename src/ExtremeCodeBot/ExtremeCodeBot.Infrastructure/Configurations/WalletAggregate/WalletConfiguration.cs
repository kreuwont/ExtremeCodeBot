using ExtremeCodeBot.Domain.Aggregates.WalletAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.WalletAggregate
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("wallet").HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Balance).IsRequired().HasColumnName("balance");

            builder.OwnsMany(x => x.Transactions);
            builder.OwnsMany(x => x.MoneyPools);

            builder.Property(x => x.LastTransactionId).HasColumnName("last_transaction_id");
        }
    }
}