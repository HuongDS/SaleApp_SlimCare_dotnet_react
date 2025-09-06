using Microsoft.AspNetCore.Mvc;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Product;
using SlimcareWeb.Service.Interfaces;
using SlimcareWeb.Service.Services;

namespace SlimcareApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        [HttpGet("/GetProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
        {
            return Ok(await _productService.GetAllAsync());
        }
        [HttpGet("/GetProduct/{id}")]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("/GetProductWithQuantity/{quantity}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsWithQuantityAsync(int quantity)
        {
            return Ok(await _productService.GetProductsWithQuantityAsync(quantity));
        }
        [HttpGet("/GetProducts/{pageIndex}/{pageSize}")]
        public async Task<ActionResult> GetProductWithPaginationAsync(int pageIndex, int pageSize)
        {
            var pagedResult = await _productService.GetProductWithPaginationAsync(pageIndex, pageSize);
            return Ok(pagedResult);
        }
        [HttpPost("/AddProduct")]
        public async Task<ActionResult<ProductViewDto>> AddAsync(CreateProductDto data)
        {
            try
            {
                var product = await _productService.AddAsync(data);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/UpdateProduct")]
        public async Task<ActionResult<ProductViewDto>> UpdateAsync(UpdateProductDto data)
        {
            try
            {
                var product = await _productService.UpdateAsync(data);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("/DeleteProduct")]
        public async Task<ActionResult<Product>> SoftDeleteAsync(int id)
        {
            try
            {
                var product = await _productService.SoftDeleteAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
