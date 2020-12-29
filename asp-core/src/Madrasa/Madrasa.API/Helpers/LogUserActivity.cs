using Madrasa.API.Extensions;
using Madrasa.Shared.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Madrasa.API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

            var userId = resultContext.HttpContext.User.GetUserId();
            if (userId == 0) return;
            var uow = resultContext.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
            if (uow == null) return;
            //var user = await uow.UserRepository.GetByIdAsync(userId);
            //user.LastActive = DateTime.UtcNow;
            //bool isSaved = await uow.Completed();
        }
    }
}
