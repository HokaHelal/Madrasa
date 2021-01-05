using Madrasa.Repository;
using Madrasa.Service.Helpers;
using Madrasa.Service.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madrasa.Repository.Account;
using Madrasa.Service.Services;
using Madrasa.Service.Interfaces;

namespace Madrasa.Service.Extenstions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            var connStr = config.GetConnectionString("DefaultConnection");

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options => { options.UseSqlServer(connStr); });
            //services.AddDbContext<DbContext>(options => { options.UseSqlServer(connStr); });

            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserUow, UserUow>();
            services.AddScoped<ISemesterUow, SemesterUow>();
            services.AddScoped<IForumUow, ForumUow>();

            return services;
        }
    }
}
