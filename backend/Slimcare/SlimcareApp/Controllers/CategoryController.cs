using Microsoft.AspNetCore.Mvc;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Category;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        [HttpGet("/GetCategory")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllAsync()
        {
            return Ok(await _categoryService.GetAllAsync());
        }
        [HttpGet("/GetCategory/{id}")]
        public async Task<ActionResult<Category>> GetByIdAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost("/AddCategory")]
        public async Task<ActionResult<CategoryViewDto>> AddAsync(CreateCategoryDto data)
        {
            try
            {
                var category = await _categoryService.AddAsync(data);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/UpdateCategory")]
        public async Task<ActionResult<CategoryViewDto>> UpdateAsync(UpdateCategoryDto data)
        {
            try
            {
                var category = await _categoryService.UpdateAsync(data);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("/DeleteCategory")]
        public async Task<ActionResult<Category>> SoftDeleteAsync(int id)
        {
            try
            {
                var category = await _categoryService.SoftDeleteAsync(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
