using backend.Contracts;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService service;
        private readonly HttpContext ?httpContext;

        public UsersController(IUsersService usersService, IHttpContextAccessor httpContextAccessor)
        {
            service = usersService;
            httpContext = httpContextAccessor.HttpContext;
        }

        private string? getToken()
        {
            return httpContext?.Request.Cookies[Config.TOKEN_NAME];
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] CreateUserDto request)
        {
            await service.Register(request);

            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserDto request)
        {
            var token = await service.Login(request.Email, request.Password);

            httpContext?.Response.Cookies.Append(Config.TOKEN_NAME, token);

            return Ok(token);
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetProfile()
        {
            var token = this.getToken();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("No token found");

            var user = await service.GetProfile(token);

            return Ok(user);
        }

        [HttpPut("profile")]
        [Authorize]
        public async Task<ActionResult<Guid>> UpdateProfile([FromBody] UpdateUserDto request)
        {
            var token = this.getToken();

            if (string.IsNullOrEmpty(token))
                return Unauthorized("No token found");

            var user = await service.UpdateProfile(token, request);

            return Ok(user);
        }
    }
}
