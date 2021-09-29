using System;

namespace ExtremeCodeBot.Domain.Aggregates.WalletAggregate
{
    public class Transaction
    {
        public virtual Guid Id { get; private set; }
        
        public virtual Wallet SenderWalletId { get; private set; }
        
        public virtual Wallet ReceiverWalletId { get; private set; }
        
        public virtual long ChangedValue { get; private set; }
        
        public virtual DateTime RegistrationTime { get; private set; }

        public Transaction(Wallet senderWalletId, Wallet receiverWalletId, long changedValue, DateTime registrationTime)
        {
            Id = Guid.NewGuid();
            SenderWalletId = senderWalletId;
            ReceiverWalletId = receiverWalletId;
            ChangedValue = changedValue;
            RegistrationTime = registrationTime;
        }
        
        /// <summary>
        /// For EF
        /// </summary>
        protected Transaction() { } 
    }
}