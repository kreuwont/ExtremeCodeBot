using System;
using ExtremeCodeBot.Domain.Aggregates.PoolAggregate;

namespace ExtremeCodeBot.Domain.Aggregates.WalletAggregate
{
    public class MoneyPool
    {
        public virtual Guid Id { get; private set; }
        
        public virtual Pool Pool { get; private set; }
        
        public virtual long CurrencyValue { get; private set; }
        
        public virtual DateTime LockTime { get; private set; }

        public virtual DateTime UnlockTime { get; private set; }

        public MoneyPool(Pool pool, long currencyValue, DateTime lockTime, DateTime unlockTime)
        {
            Id = Guid.NewGuid();
            Pool = pool ?? throw new ArgumentNullException(nameof(pool));
            CurrencyValue = currencyValue;
            LockTime = lockTime;
            UnlockTime = unlockTime;
        }
        
        /// <summary>
        /// For EF
        /// </summary>
        protected MoneyPool() { }
    }
}