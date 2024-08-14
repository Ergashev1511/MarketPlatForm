using MarketPlatForm.Api.DBcontext;
using MarketPlatForm.Api.Models;
using MarketPlatForm.Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MarketPlatForm.Api.Repositories.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> AddAsync(Category category)
        {
            if(category == null) throw new ArgumentNullException(nameof(category));
            await _context.categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.categories.Where(a=>a.Id>0).ToListAsync();
        }

        public async Task<Category> GetById(long Id)
        {
            var category=await _context.categories.FirstOrDefaultAsync(a=>a.Id==Id);
            return category;
        }
    }
}
