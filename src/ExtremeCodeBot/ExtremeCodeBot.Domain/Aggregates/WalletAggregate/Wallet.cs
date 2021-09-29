using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtremeCodeBot.Domain.Aggregates.WalletAggregate
{
    public class Wallet
    {
        public virtual Guid Id { get; private set; }
        
        public virtual long Balance { get; private set; }
        
        public virtual Guid? LastTransactionId { get; private set; }

        public virtual IReadOnlyCollection<Transaction> Transactions { get; private set; }
        
        public virtual IReadOnlyCollection<MoneyPool> MoneyPools { get; private set; }

        public Wallet(long balance, Guid? lastTransactionId, IEnumerable<Transaction> transactions, IEnumerable<MoneyPool> moneyPools)
        {
            var transactionList = transactions?.ToList();
            var moneyPoolsList = moneyPools?.ToList();

            Id = Guid.NewGuid();
            Balance = balance;
            LastTransactionId = lastTransactionId;
            Transactions = transactionList ?? throw new ArgumentNullException(nameof(transactions));
            MoneyPools = moneyPoolsList ?? throw new ArgumentNullException(nameof(moneyPools));
        }

        /// <summary>
        /// For EF
        /// </summary>
        protected Wallet() {}

        /// <summary>
        /// Фабрика
        /// </summary>
        public static Wallet Create()
        {
            return new Wallet(0, 
                null,
                Enumerable.Empty<Transaction>(),
                Enumerable.Empty<MoneyPool>());
        }
    }
}