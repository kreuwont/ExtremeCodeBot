using System.Threading;
using System.Threading.Tasks;
using ExtremeCodeBot.Domain.SeedWork;

namespace ExtremeCodeBot.Domain.Aggregates.ClientAggregate
{
    public interface IClientRepository
    {
        IUnitOfWork UnitOfWork { get; }
        
        void Add(Client client);
        
        Task<Client> GetById(long telegramId, CancellationToken cancellationToken = default);
        Task<Client> GetByTelegramId(long telegramId, CancellationToken cancellationToken = default);
    }
}