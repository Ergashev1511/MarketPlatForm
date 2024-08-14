using MarketPlatForm.Api.DBcontext;
using MarketPlatForm.Api.Models;
using MarketPlatForm.Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MarketPlatForm.Api.Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
           
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.products.Where(a => a.Id > 0).ToListAsync();
        }

        public async Task<Product> GetById(long Id)
        {
            var product = await _context.products.FirstOrDefaultAsync(a => a.Id == Id);
            return product ?? throw new ArgumentNullException(nameof(product));
        }

    }
}
