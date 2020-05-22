using System.Threading.Tasks;
using ShopWarehouse.API.Data.Interfaces;
using ShopWarehouse.API.Data.Models;

namespace ShopWarehouse.API.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;

        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddProduct(Product dto)
        {
            await _appDbContext.Products.AddAsync(dto);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
