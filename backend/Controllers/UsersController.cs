using backend.Abstractions;
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
        private readonly IToolkit _toolkit;
        private readonly HttpContext ?httpContext;

        public UsersController(IUsersService usersService, IToolkit toolkit, IHttpContextAccessor httpContextAccessor)
        {
            service = usersService;
            _toolkit = toolkit;
            httpContext = httpContextAccessor.HttpContext;
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

        [HttpPost("logout")]
        [AllowAnonymous]
        public ActionResult<string> Logout()
        {
            httpContext?.Response.Cookies.Delete(Config.TOKEN_NAME);

            return Ok("You have been logged out");
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetProfile()
        {
            var token = _toolkit.getUserToken(httpContext);

            if (string.IsNullOrEmpty(token))
                return Unauthorized("No token found");

            var user = await service.GetProfile(token);

            return Ok(user);
        }

        [HttpPut("profile")]
        [Authorize]
        public async Task<ActionResult<Guid>> UpdateProfile([FromBody] UpdateUserDto request)
        {
            var token = _toolkit.getUserToken(httpContext);

            if (string.IsNullOrEmpty(token))
                return Unauthorized("No token found");

            var user = await service.UpdateProfile(token, request);

            return Ok(user);
        }
    }
}
