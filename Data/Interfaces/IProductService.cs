using System.Threading.Tasks;
using ShopWarehouse.API.Data.Models;

namespace ShopWarehouse.API.Data.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(Product dto);
    }
}
