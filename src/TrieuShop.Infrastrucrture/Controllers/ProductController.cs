using Microsoft.AspNetCore.Mvc;
using TrieuShop.Core.Services;
using TrieuShop.Domain.Entities;

namespace TrieuShop.Infrastrucrture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = (await productService.GetAll()).Select(x=> new {x.ProductId,x.ProductName});

            return Ok(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] string productName)
        {
            var data = (await productService.Add(new Product(){ProductName = productName}));

            return Ok(data);
        }
    }
}
