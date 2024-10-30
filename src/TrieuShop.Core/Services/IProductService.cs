using TrieuShop.Core.Common;
using TrieuShop.Domain.Entities;

namespace TrieuShop.Core.Services
{
    public interface IProductService : IServiceBase<Domain.Entities.Product,int>
    {
        public EventHandler<Product> AddNewProductHandler { get; set; }
        public EventHandler<Product> DeleteEventHandler { get; set; }
        public Task UpdateQuantity(Product product,int quantity);
    }
}
