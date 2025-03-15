using backend.Communication.Contracts;
using backend.Domain.Abstractions;
using backend.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService service;
        private readonly IToolkit _toolkit;
        private readonly HttpContext? httpContext;

        public UsersController(IUsersService usersService, IToolkit toolkit, IHttpContextAccessor httpContextAccessor)
        {
            service = usersService;
            _toolkit = toolkit;
            httpContext = httpContextAccessor.HttpContext;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IResult> Register([FromBody] CreateUserDto request)
        {
            await service.Register(request);

            return ResultResponse.Ok("Register successfully");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IResult> Login([FromBody] LoginUserDto request)
        {
            var res = await service.Login(request.Email, request.Password);

            httpContext?.Response.Cookies.Append(Config.TOKEN_NAME, res.token);

            return ResultResponse.Ok(res);
        }

        [HttpPost("logout")]
        [AllowAnonymous]
        public IResult Logout()
        {
            httpContext?.Response.Cookies.Delete(Config.TOKEN_NAME);

            return ResultResponse.Ok("You have been logged out");
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IResult> GetProfile()
        {
            var token = _toolkit.getUserToken(httpContext);

            if (string.IsNullOrEmpty(token))
                return ResultResponse.Unauthorized();

            var user = await service.GetProfile(token);

            return ResultResponse.Ok(user);
        }

        [HttpPut("profile")]
        [Authorize]
        public async Task<IResult> UpdateProfile([FromBody] UpdateUserDto request)
        {
            var token = _toolkit.getUserToken(httpContext);

            if (string.IsNullOrEmpty(token))
                return ResultResponse.Unauthorized();

            var user = await service.UpdateProfile(token, request);

            return ResultResponse.Ok(user);
        }
    }
}
