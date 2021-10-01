using System;
using System.Collections.Generic;
using System.Linq;
using ExtremeCodeBot.Domain.Aggregates.PoolAggregate;
using ExtremeCodeBot.Domain.Aggregates.WalletAggregate;

namespace ExtremeCodeBot.Domain.Aggregates.ClientAggregate
{
    public class Client
    {
        public virtual Guid Id { get; private set; }

        public virtual int? TelegramId { get; private set; }

        public virtual string Name { get; private set; }

        public virtual bool IsAdmin { get; private set; }

        public virtual Wallet Wallet { get; private set; }

        public virtual IReadOnlyCollection<BlockHistory> BlockHistories { get; private set; }

        public virtual IReadOnlyCollection<ItemSlot> ItemSlots { get; private set; }

        public virtual IReadOnlyCollection<Pool> Pools { get; private set; }

        public Client(int? telegramId, string name, bool isAdmin, Wallet wallet,
            IEnumerable<BlockHistory> blockHistories,
            IEnumerable<ItemSlot> itemSlots)
        {
            var blockHistoryList = blockHistories?.ToList();
            var itemSlotsList = itemSlots?.ToList();

            Id = Guid.NewGuid();
            TelegramId = telegramId;
            Name = name;
            IsAdmin = isAdmin;
            Wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            BlockHistories = blockHistoryList ?? throw new ArgumentNullException(nameof(blockHistories));
            ItemSlots = itemSlotsList ?? throw new ArgumentNullException(nameof(itemSlots));
        }

        /// <summary>
        /// For EF
        /// </summary>
        protected Client()
        {
        }

        /// <summary>
        /// Фабрика
        /// </summary>
        /// <param name="telegramId"><see cref="TelegramId"/></param>
        /// <param name="name"><see cref="Name"/></param>
        /// <param name="isAdmin"><see cref="IsAdmin"/></param>
        /// <returns><see cref="Client"/></returns>
        public static Client Create(int? telegramId, string name, bool isAdmin)
        {
            return new Client(telegramId, name, isAdmin, Wallet.Create(),
                Enumerable.Empty<BlockHistory>(),
                Enumerable.Empty<ItemSlot>());
        }
    }
}