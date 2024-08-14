using MarketPlatForm.Api.Models;
using MarketPlatForm.Api.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlatForm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;   
        }


        [HttpPost("Create")]
        public async ValueTask<IActionResult> Create(Product product)
        {
            return Ok(await productService.Create(product));
        }


        [HttpGet("Id")]
        public async ValueTask<IActionResult> GetById(long  Id)
        {
            return Ok(await productService.GetById(Id));
        }


        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll()
        {
            return Ok(await productService.GetAll());
        }
    }
}
