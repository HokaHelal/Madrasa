using Madrasa.Repository;
using Madrasa.Repository.Account;
using Madrasa.Repository.Generic;
using Madrasa.Repository.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Madrasa.API
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                var connStr = _config.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connStr);
            });
            services.AddDbContext<DbContext>(options =>
            {
                var connStr = _config.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connStr);
            });
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IGenericUnitOfWork, GenericUnitOfWork>();
            services.AddScoped<IUserUow, UserUow>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
