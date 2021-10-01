using ExtremeCodeBot.Domain.Aggregates.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.ClientAggregate
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client").HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.TelegramId).HasColumnName("telegram_id");
            builder.Property(x => x.Name).IsRequired().HasColumnName("name");
            builder.Property(x => x.IsAdmin).HasColumnName("is_admin");

            builder.HasOne(x => x.Wallet)
                .WithOne(x => x.Client)
                .HasForeignKey("client_id");

            builder.OwnsMany(x => x.BlockHistories);

            builder.OwnsMany(x => x.ItemSlots);
        }
    }
}