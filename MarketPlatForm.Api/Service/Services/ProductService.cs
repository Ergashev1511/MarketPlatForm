using MarketPlatForm.Api.Models;
using MarketPlatForm.Api.Repositories.IRepositories;
using MarketPlatForm.Api.Service.IService;

namespace MarketPlatForm.Api.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Product> Create(Product product)
        {
            if(product == null)  throw new ArgumentNullException(nameof(product));
            await repository.AddAsync(product);
           return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<Product> GetById(long id)
        {
            var product = await repository.GetById(id);
            return product;
        }
    }
}
