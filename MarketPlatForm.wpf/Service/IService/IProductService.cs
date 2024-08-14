using MarketPlatForm.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlatForm.wpf.Service.IService
{
    public interface IProductService
    {
        Task<bool> Create(Product product);
        Task<Product> GetById(long Id);
        Task<List<Product>> GetAll();
    }
}
