using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using App.Persistence;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories.Categories
{
    public class CategoryRepository(AppDbContext context)
        : GenericRepository<Category, int>(context), ICategoryRepository
    {
        public Task<Category?> GetCategoryWithProductsAsync(int id)
        {
            return context.GetDbSet<Category>().Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Category>> GetCategoryWithProductsAsync()
        {
            return context.GetDbSet<Category>().Include(x => x.Products).ToListAsync();
        }

        public IQueryable<Category> GetCategoryWithProducts()
        {
            return context.GetDbSet<Category>().Include(x => x.Products).AsQueryable();
        }
    }
}