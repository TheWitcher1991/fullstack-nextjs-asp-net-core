using backend.Abstractions;
using backend.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService service;

        public CategoriesController(ICategoriesService categoriesService)
        {
            service = categoriesService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await service.GetAllCategories();

            return Ok(categories);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
        {
            return Ok(await service.GetCategory(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateCategory([FromBody] CreateCategoryDto request)
        {
            var categoryId = await service.CreateCategory(request);

            return Ok(categoryId);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<Guid>> DeleteCategory(Guid id)
        {
            return Ok(await service.DeleteCategory(id));
        }
    }
}
