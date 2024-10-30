namespace TrieuShop.Core.Common
{
    public interface IRepositoryBase<T,TId> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(T entity);

        public Task<T?> FindById(TId id);
    }
}
