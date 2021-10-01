using ExtremeCodeBot.Domain.Aggregates.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExtremeCodeBot.Infrastructure.Configurations.ClientAggregate
{
    public class BlockHistoryConfiguration : IEntityTypeConfiguration<BlockHistory>
    {
        public void Configure(EntityTypeBuilder<BlockHistory> builder)
        {
            builder.ToTable("block_history").HasKey(x => x.Id).HasName("id");

            builder.OwnsOne(x => x.AdminClient);
            
            builder.Property(x => x.BlockClientType)
                .HasConversion(new EnumToStringConverter<BlockClientTypes>())
                .HasColumnName("block_client_type");

            builder.Property(x => x.Reason).HasColumnName("reason");
            builder.Property(x => x.BanTime).IsRequired().HasColumnName("ban_time");
            builder.Property(x => x.UnbanTime).HasColumnName("unban_time");
        }
    }
}