using System;
using ExtremeCodeBot.Domain.Aggregates.ClientAggregate;
using ExtremeCodeBot.Domain.SeedWork;

namespace ExtremeCodeBot.Domain.Aggregates.PoolAggregate
{
    public class Pool
    {
        public virtual Guid Id { get; private set; }
        
        public virtual string Name { get; private set; }
        
        public virtual float IncreasePercent { get; private set; }
        
        public virtual bool IsActive { get; private set; }
        
        public virtual TimeSpan LockTime { get; private set; }
        
        public virtual DateTime OpenTime { get; private set; }
        
        public virtual DateTime CloseTime { get; private set; }
        
        public virtual DateTime CreatedTime { get; private set; }
        
        public virtual Client Creator { get; private set; }

        public Pool(string name, float increasePercent, TimeSpan lockTime, DateTime openTime,
            DateTime closeTime, Client creator)
        {
            Id = Guid.NewGuid();
            Name = name;
            IncreasePercent = increasePercent > 0 
                ? increasePercent 
                : throw new DomainException("Increase percent must be greater than 0");
            IsActive = false;
            LockTime = lockTime;
            OpenTime = openTime;
            CloseTime = closeTime;
            CreatedTime = DateTime.UtcNow;
            Creator = creator ?? throw new ArgumentNullException(nameof(creator));
        }
        
        /// <summary>
        /// For EF
        /// </summary>
        protected Pool() {}
    }
}