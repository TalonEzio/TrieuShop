using TrieuShop.Core.Repositories;
using TrieuShop.Domain.Entities;

namespace TrieuShop.Infrastructure.InMemory.Repositories
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private static int _id;

        public static int NextId => _id++;

        public static List<Product> Products { get; set; } =
        [
            new Product { ProductId = NextId, ProductName = "Test 1" },
            new Product { ProductId = NextId, ProductName = "Test 2" },
            new Product { ProductId = NextId, ProductName = "Test 3" },
            new Product { ProductId = NextId, ProductName = "Test 4" }
        ];
        public Task<IEnumerable<Product>> GetAll()
        {
            return Task.FromResult(Products.AsEnumerable());
        }

        public Task<Product> Add(Product entity)
        {
            entity.ProductId = NextId;
            Products.Add(entity);

            return Task.FromResult(entity);
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Product entity)
        {
            Products.Remove(entity);
            return Task.FromResult(true);
        }

        public Task<Product?> FindById(int id)
        {
            return Task.FromResult(Products.FirstOrDefault(x => x.ProductId == id));
        }
    }
}
