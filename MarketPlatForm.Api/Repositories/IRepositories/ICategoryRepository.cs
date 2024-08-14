using MarketPlatForm.Api.Models;

namespace MarketPlatForm.Api.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category);
        Task<Category> GetById(long Id);
        Task<List<Category>> GetAll();
    }
}
