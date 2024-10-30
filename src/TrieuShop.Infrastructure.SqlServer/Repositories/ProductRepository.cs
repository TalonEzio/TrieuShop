using System.Data;
using Dapper;
using TrieuShop.Core.Repositories;
using TrieuShop.Domain.Entities;

namespace TrieuShop.Infrastructure.SqlServer.Repositories
{
    public class ProductRepository(IDbConnection dbConnection) : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await dbConnection.QueryAsync<Product>("Select * from Products");
        }

        public async Task<Product> Add(Product entity)
        {
            var dynamicParams = new DynamicParameters();

            dynamicParams.Add("ProductId", 0, DbType.Int32,ParameterDirection.Output);
            dynamicParams.Add("Name", entity.ProductName, DbType.String, size: 50);

            await dbConnection.ExecuteAsync("usp_InsertNewProduct",  dynamicParams, commandType: CommandType.StoredProcedure);

            entity.ProductId = dynamicParams.Get<int>("@ProductId");

            return entity;
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
