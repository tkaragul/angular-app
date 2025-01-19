using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories.Products
{
    public class ProductRepository(AppDbContext context)
        : GenericRepository<Product, int>(context), IProductRepository
    {
        public Task<List<Product>> GetTopPriceProductsAsync(int count)
        {
            return Context.GetDbSet<Product>().OrderByDescending(x => x.Price).Take(count).ToListAsync();
        }
    }
}