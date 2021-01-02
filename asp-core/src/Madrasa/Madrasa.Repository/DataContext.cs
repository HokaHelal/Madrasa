using Madrasa.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.Repository
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
