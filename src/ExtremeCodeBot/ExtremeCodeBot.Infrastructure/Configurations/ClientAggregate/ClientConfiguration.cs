using ExtremeCodeBot.Domain.Aggregates.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.ClientAggregate
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.TelegramId).HasColumnName("telegram_id");
            builder.Property(x => x.Name).IsRequired().HasColumnName("name");
            builder.Property(x => x.IsAdmin).HasColumnName("is_admin");

            builder.OwnsOne(x => x.Wallet);

            builder.OwnsMany(x => x.BlockHistories);

            builder.OwnsMany(x => x.ItemSlots);
        }
    }
}