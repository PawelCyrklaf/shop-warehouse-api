using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopWarehouse.API.Data.Models;

namespace ShopWarehouse.API.Data.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(Product dto);
        Task<Product> GetProduct(int productId);
        Task<List<Product>> GetProducts();
        Task<ActionResult> RemoveProduct(int productId);
    }
}
