using MarketPlatForm.Api.Models;
using MarketPlatForm.Api.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlatForm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;          
        }


        [HttpPost("Create")]
        public async ValueTask<IActionResult> Create(Category category)
        {
            return Ok(await categoryService.Create(category));
        }

        [HttpGet("id")]
        public async ValueTask<IActionResult> GetById(long Id)
        {
            return Ok(await categoryService.GetById(Id));
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll()
        {
            return Ok(await categoryService.GetAll());
        }

    }
}
