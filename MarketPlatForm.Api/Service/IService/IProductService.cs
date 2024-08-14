using MarketPlatForm.Api.Models;

namespace MarketPlatForm.Api.Service.IService
{
    public interface IProductService
    {
        Task<Product> Create(Product product);
        Task<Product> GetById(long id);
        Task<List<Product>> GetAll();
    }
}
