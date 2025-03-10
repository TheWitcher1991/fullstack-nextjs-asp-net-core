using backend.Abstractions;
using backend.Contracts;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesService service;
        private readonly HttpContext? httpContext;

        public FavoritesController(IFavoritesService favoritesService, IHttpContextAccessor httpContextAccessor)
        {
            service = favoritesService;
            httpContext = httpContextAccessor.HttpContext;
        }

        private string? getToken()
        {
            return httpContext?.Request.Cookies[Config.TOKEN_NAME];
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<FavoriteDto>>> GetFavorites()
        {
            var token = this.getToken();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("No token found");

            var response = await service.GetAllFavorites(token);

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> AddFavorite([FromBody] CreateFavoriteDto request)
        {
            var token = this.getToken();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("No token found");

            var response = await service.AddFavorite(token, request);

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<Guid>> DeleteFavorite(Guid id)
        {
            return Ok(await service.DeleteFavorite(id));
        }
    }
}
