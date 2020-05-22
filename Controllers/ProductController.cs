using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopWarehouse.API.Data.Interfaces;
using ShopWarehouse.API.Data.Models;

namespace ShopWarehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productService.AddProduct(product);
            return Ok();
        }
    }
}
