using MarketPlatForm.Api.Models;

namespace MarketPlatForm.Api.Repositories.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(long Id);
        Task<List<Product>> GetAll();
        Task AddAsync(Product product);
    }
}
