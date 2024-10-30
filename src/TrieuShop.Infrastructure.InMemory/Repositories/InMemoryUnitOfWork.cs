using TrieuShop.Core.Common;

namespace TrieuShop.Infrastructure.InMemory.Repositories
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public Task<int> Save()
        {
            throw new NotImplementedException();
        }
    }
}
