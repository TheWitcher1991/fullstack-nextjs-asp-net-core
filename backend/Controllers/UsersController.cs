using backend.Contracts;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController
    {
        private readonly IUsersService service;

        public UsersController(IUsersService usersService)
        {
            service = usersService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IResult> Register([FromBody] CreateUserDto request)
        {
            await service.Register(request);

            return Results.Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IResult> Login([FromBody] LoginUserDto request, HttpContext context)
        {
            var token = await service.Login(request.email, request.password);

            context.Response.Cookies.Append(Config.TOKEN_NAME, token);

            return Results.Ok(token);
        }

    }
}
