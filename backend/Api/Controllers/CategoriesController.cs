using backend.Communication.Contracts;
using backend.Domain.Abstractions;
using backend.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Api.Controllers
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
        public async Task<IResult> GetCategories()
        {
            var categories = await service.GetAllCategories();

            return ResultResponse.Ok(categories);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IResult> GetCategory(Guid id)
        {
            return ResultResponse.Ok(await service.GetCategory(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<IResult> CreateCategory([FromBody] CreateCategoryDto request)
        {
            var categoryId = await service.CreateCategory(request);

            return ResultResponse.Ok(categoryId);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IResult> DeleteCategory(Guid id)
        {
            return ResultResponse.Ok(await service.DeleteCategory(id));
        }
    }
}
