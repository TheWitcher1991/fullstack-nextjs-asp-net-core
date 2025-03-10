using backend.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController
    {
        private readonly ICategoriesService service;

        public CategoriesController(ICategoriesService categoriesService)
        {
            service = categoriesService;
        }
    }
}
