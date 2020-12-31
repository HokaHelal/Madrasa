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
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
