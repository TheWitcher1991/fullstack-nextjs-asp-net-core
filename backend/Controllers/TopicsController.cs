using backend.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicsController
    {
        private readonly ITopicsService service;

        public TopicsController(ITopicsService topicsService)
        {
            service = topicsService;
        }
    }
}
