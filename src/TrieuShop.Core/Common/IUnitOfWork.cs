namespace TrieuShop.Core.Common
{
    public interface IUnitOfWork
    {
        public Task<int> Save();
    }
}
