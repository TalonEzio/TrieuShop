using TrieuShop.Core.Common;
using TrieuShop.Core.Repositories;
using TrieuShop.Domain.Entities;

namespace TrieuShop.Core.Services
{
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductService
    {
        public EventHandler<Product>? AddNewProductHandler { get; set; } 
        public EventHandler<Product>? DeleteEventHandler { get; set; }

        public Task<IEnumerable<Product>> GetAll()
        {
            return productRepository.GetAll();
        }

        public async Task<Product> Add(Product entity)
        {
            //....

            await productRepository.Add(entity);

            //thể hiện công việc gì đó...
            AddNewProductHandler?.Invoke(this,entity);

            return entity;
        }

        public async Task<Product> Update(Product entity)
        {
            await productRepository.Update(entity);


            return entity;
        }

        public async Task<bool> Delete(Product entity)
        {
            try
            {
                await productRepository.Delete(entity);

                DeleteEventHandler.Invoke(this, entity);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public async  Task UpdateQuantity(Product product, int quantity)
        {
            var productId = product.ProductId;

            var updateProduct = await productRepository.FindById(productId);

            if (updateProduct == null) throw new Exception("Đéo thấy con mẹ gì");

            updateProduct.Price = quantity;

            await unitOfWork.Save();

        }
    }
}
