using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsPortal.Data;
using NewsPortal.Data.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, UserContext userContext, IServiceScopeFactory scopeFactory)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DataContext>();
                var user = await context.Users.SingleOrDefaultAsync(u =>
                    u.ApiKey == httpContext.Request.Headers["ApiKey"]);
                if (user != null)
                {
                    userContext.UserId = user.Id;
                    userContext.Role = user.SystemRole;
                }
                else
                {
                    userContext = new UserContext();
                }
            }

            await _next(httpContext);
        }
    }
}
