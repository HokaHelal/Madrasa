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
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().HasMany<Topic>(s => s.Topics).WithOne(c => c.Author)
                 .OnDelete(DeleteBehavior.NoAction)
                 .HasForeignKey(ur => ur.AuthorId);
           
            builder.Entity<AppUser>().HasMany<Post>(s => s.Posts).WithOne(c => c.Author)
                 .OnDelete(DeleteBehavior.NoAction)
                 .HasForeignKey(ur => ur.AuthorId);

            builder.Entity<Topic>().HasMany<AppUser>(s => s.UserLikes).WithMany(c => c.TopicsLiked);
            builder.Entity<Post>().HasMany<AppUser>(s => s.UserLikes).WithMany(c => c.PostsLiked);   
        }


    }
}
