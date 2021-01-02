﻿using Madrasa.Repository;
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

namespace Madrasa.Service.Extenstions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            var connStr = config.GetConnectionString("DefaultConnection");

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddDbContext<DataContext>(options => { options.UseSqlServer(connStr); });
            //services.AddDbContext<DbContext>(options => { options.UseSqlServer(connStr); });

            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserUow, UserUow>();
            services.AddScoped<ISemesterUow, SemesterUow>();

            return services;
        }
    }
}
