using System;

namespace ExtremeCodeBot.Domain.Aggregates.ClientAggregate
{
    public class BlockHistory
    {
        public virtual Guid Id { get; private set; }
        
        public virtual Client AdminClient { get; private set; }
        
        public virtual BlockClientTypes BlockClientType { get; private set; }
        
        public virtual string Reason { get; private set; }
        
        public virtual DateTime BanTime { get; private set; }
        
        public virtual DateTime? UnbanTime { get; private set; }

        public BlockHistory(Client adminClient, BlockClientTypes blockClientType, string reason, DateTime banTime,
            DateTime? unbanTime)
        {
            Id = Guid.NewGuid();
            AdminClient = adminClient ?? throw new ArgumentNullException(nameof(adminClient));
            BlockClientType = blockClientType;
            Reason = reason;
            BanTime = banTime;
            UnbanTime = unbanTime;
        }
        
        /// <summary>
        /// For EF
        /// </summary>
        protected BlockHistory() {}
    }
}