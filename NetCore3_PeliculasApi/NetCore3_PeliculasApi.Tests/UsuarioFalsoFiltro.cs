using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCore3_PeliculasApi.Tests
{
    public class UsuarioFalsoFiltro: IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Email, "example@hotmail.com"),
                    new Claim(ClaimTypes.Name, "example@hotmail.com"),
                    new Claim(ClaimTypes.NameIdentifier, "adadasdad-aasda-asda3-2312as1-123213213"),
                }, "Test"));

            await next();
        }
    }
}
