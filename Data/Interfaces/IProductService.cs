using System.Collections.Generic;
using System.Threading.Tasks;
using ShopWarehouse.API.Data.Models;

namespace ShopWarehouse.API.Data.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(Product dto);
        Task<Product> GetProduct(int productId);
        Task<List<Product>> GetProducts();
    }
}
