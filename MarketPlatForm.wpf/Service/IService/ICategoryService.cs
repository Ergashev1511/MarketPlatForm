using MarketPlatForm.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlatForm.wpf.Service.IService
{
    public interface ICategoryService
    {
        Task<bool> Create(Category category);
        Task<Category> GetById(long Id);
        Task<List<Category>> GetAll();
    }
}
