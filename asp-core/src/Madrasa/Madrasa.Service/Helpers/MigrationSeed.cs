﻿using Madrasa.Models;
using Madrasa.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Service.Helpers
{
    public class MigrationSeed
    {
        public async static Task Invoke(IServiceProvider services)
        {
            try
            {
                var context = services.GetRequiredService<DataContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
                await context.Database.MigrateAsync();

                await Seed.SeedLookups(context);
                await Seed.SeedUsers(userManager, roleManager, context);
                await Seed.SeedForum(context);                
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<MigrationSeed>>();
                logger.LogError(ex, "An error occured during migration");
            }
        }
    }
}
