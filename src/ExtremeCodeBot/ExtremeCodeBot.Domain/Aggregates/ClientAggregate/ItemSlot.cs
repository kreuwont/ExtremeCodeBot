using System;

namespace ExtremeCodeBot.Domain.Aggregates.ClientAggregate
{
    public class ItemSlot
    {
        public virtual Guid Id { get; private set; }

        // todo:
        public virtual Guid ItemId { get; private set; }

        public virtual DateTime ReceivedTime { get; private set; }

        public virtual DateTime UsedTime { get; private set; }

        /// <summary>
        /// For EF
        /// </summary>
        protected ItemSlot()
        {
        }
    }
}