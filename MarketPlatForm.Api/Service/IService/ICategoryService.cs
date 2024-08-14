using MarketPlatForm.Api.Models;

namespace MarketPlatForm.Api.Service.IService
{
    public interface ICategoryService
    {
        Task<Category> Create(Category category);
        Task<Category> GetById(long id);
        Task<List<Category>> GetAll();
    }
}
