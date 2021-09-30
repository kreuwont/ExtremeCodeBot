using System;
using ExtremeCodeBot.Domain.Aggregates.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.ClientAggregate
{
    public class BlockHistoryConfiguration : IEntityTypeConfiguration<BlockHistory>
    {
        public void Configure(EntityTypeBuilder<BlockHistory> builder)
        {
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.BlockClientType).HasConversion(
                    v => v.ToString(),
                    v => (BlockClientTypes) Enum.Parse(typeof(BlockClientTypes), v))
                .HasColumnName("block_client_type");

            builder.Property(x => x.Reason).HasColumnName("reason");
            builder.Property(x => x.BanTime).HasColumnName("ban_time");
            builder.Property(x => x.UnbanTime).HasColumnName("unban_time");
        }
    }
}