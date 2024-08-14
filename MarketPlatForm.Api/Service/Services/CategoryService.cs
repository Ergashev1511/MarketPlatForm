using MarketPlatForm.Api.Models;
using MarketPlatForm.Api.Repositories.IRepositories;
using MarketPlatForm.Api.Service.IService;

namespace MarketPlatForm.Api.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;
        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;   
        }
        public async Task<Category> Create(Category category)
        {
            if(category == null) throw new ArgumentNullException("category");
            return await repository.AddAsync(category);

        }

        public async Task<List<Category>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<Category> GetById(long id)
        {
            var category=await repository.GetById(id);
            return category;
        }
    }
}
