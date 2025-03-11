﻿using backend.Abstractions;
using backend.Repositories;

namespace backend.Toolkit
{
    public class Toolkit : IToolkit
    {
        private readonly IJwtProvider _jwtProvider;

        public Toolkit(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }

        public string? getUserToken(HttpContext ?httpContext)
        {
            if (httpContext == null)
            {
                return null;
            }

            return httpContext.Request.Cookies[Config.TOKEN_NAME];
        }

        public Guid getUserGuid(HttpContext ?httpContext)
        {
            if (httpContext == null)
            {
                return Guid.Empty;
            }

            var token = this.getUserToken(httpContext);

            if (token == null)
                return Guid.Empty;

            var userId = _jwtProvider.Decode(token);

            return userId;
        }
    }
}
