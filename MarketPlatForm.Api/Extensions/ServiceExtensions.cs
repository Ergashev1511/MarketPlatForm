using MarketPlatForm.Api.DBcontext;
using MarketPlatForm.Api.Repositories.IRepositories;
using MarketPlatForm.Api.Repositories.Repositories;
using MarketPlatForm.Api.Service.IService;
using MarketPlatForm.Api.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace MarketPlatForm.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDbContextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }


        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}
