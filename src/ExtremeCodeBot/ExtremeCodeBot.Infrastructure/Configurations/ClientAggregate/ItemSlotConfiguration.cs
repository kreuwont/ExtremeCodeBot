using ExtremeCodeBot.Domain.Aggregates.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtremeCodeBot.Infrastructure.Configurations.ClientAggregate
{
    public class ItemSlotConfiguration : IEntityTypeConfiguration<ItemSlot>
    {
        public void Configure(EntityTypeBuilder<ItemSlot> builder)
        {
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.ItemId).HasColumnName("item_id");
            builder.Property(x => x.ReceivedTime).HasColumnName("received_time");
            builder.Property(x => x.UsedTime).HasColumnName("used_time");
        }
    }
}