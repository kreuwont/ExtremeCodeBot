using ExtremeCodeBot.Domain.Aggregates.WalletAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.WalletAggregate
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transaction").HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.ChangedValue).IsRequired().HasColumnName("changed_value");
            builder.Property(x => x.RegistrationTime).IsRequired().HasColumnName("registration_time");

            builder.HasOne(x => x.ReceiverWalletId)
                .WithMany(x => x.Transactions)
                .HasForeignKey("receiver_id");

            builder.HasOne(x => x.SenderWalletId)
                .WithMany(x => x.Transactions)
                .HasForeignKey("sender_id");
        }
    }
}