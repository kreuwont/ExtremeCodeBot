using ExtremeCodeBot.Domain.Aggregates.WalletAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.WalletAggregate
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.ChangedValue).HasColumnName("changed_value");
            builder.Property(x => x.RegistrationTime).HasColumnName("registration_time");
        }
    }
}