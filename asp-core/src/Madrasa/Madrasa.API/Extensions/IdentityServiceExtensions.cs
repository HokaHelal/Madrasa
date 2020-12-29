using Madrasa.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Madrasa.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
            })
            .AddRoles<AppRole>()
            .AddRoleManager<RoleManager<AppRole>>()
            .AddSignInManager<SignInManager<AppUser>>()
            .AddRoleValidator<RoleValidator<AppRole>>()
            .AddEntityFrameworkStores<DataContext>();

            //services
            //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
            //    {
            //        opts.TokenValidationParameters = new TokenValidationParameters()
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
            //            ValidateIssuer = false,
            //            ValidateAudience = false

            //        };
            //        opts.Events = new JwtBearerEvents
            //        {
            //            OnMessageReceived = ctx =>
            //            {
            //                var accessToken = ctx.Request.Query["access_token"];
            //                var path = ctx.HttpContext.Request.Path;
            //                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
            //                {
            //                    ctx.Token = accessToken;
            //                }

            //                return Task.CompletedTask;
            //            }
            //        };
            //    });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                opt.AddPolicy("ModeratePhotoRole", policy => policy.RequireRole("Admin", "Moderator"));
            });

            return services;
        }

    }
}
