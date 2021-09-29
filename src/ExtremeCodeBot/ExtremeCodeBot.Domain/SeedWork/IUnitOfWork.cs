using System.Threading;
using System.Threading.Tasks;

namespace ExtremeCodeBot.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}