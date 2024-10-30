using System.Data;
using Microsoft.Data.SqlClient;
using TrieuShop.Core.Common;
using TrieuShop.Core.Repositories;
using TrieuShop.Core.Services;
using TrieuShop.Infrastructure.SqlServer.Repositories;

namespace TrieuShop.Infrastrucrture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var services = builder.Services;

            services.AddScoped<IDbConnection>(_
                => new SqlConnection(builder.Configuration.GetConnectionString(nameof(TrieuShop))
                ));
            services.AddScoped<IProductService, ProductService>();

#if UseSqlServer
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
#elif UseInMemory
                        services.AddScoped<IUnitOfWork, InMemoryUnitOfWork>();
                        services.AddScoped<IProductRepository, ProductInMemoryRepository>();
#endif


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
