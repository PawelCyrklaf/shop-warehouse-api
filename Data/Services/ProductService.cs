using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Product> GetProduct(int productId)
        {
            return await _appDbContext.Products.FindAsync(productId);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _appDbContext.Products.ToListAsync();
        }


        public async Task<ActionResult> RemoveProduct(int productId)
        {
            var product = await _appDbContext.Products.FindAsync(productId);

            if(product == null)
            {
                return new NotFoundResult();
            }

            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();

            return new OkResult();
        }

        public async Task UpdateProduct(Product product)
        {
                _appDbContext.Update(product);
                await _appDbContext.SaveChangesAsync();

        }
    }
}
