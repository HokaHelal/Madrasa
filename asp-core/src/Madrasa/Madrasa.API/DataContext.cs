using Madrasa.API.Models;
using Madrasa.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Madrasa.API
{
    public class DataContext  : IdentityDbContext<AppUser, AppRole, int>
    {

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Student> Students { get; set; } 
        DbSet<Teacher> Teachers { get; set; } 
        DbSet<Class> Classes { get; set; } 
        DbSet<Grade> Grades { get; set; } 
        DbSet<Manager> Managers { get; set; } 
        DbSet<Session> Sessions { get; set; } 
        DbSet<Subject> Subjects { get; set; } 
        DbSet<Timeframe> Timeframes { get; set; } 
        DbSet<Timetable> Timetables { get; set; } 
        DbSet<Weekday> Weekdays { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            UtcDateAnnotation.ApplyUtcDateTimeConverter(builder);
        }
    }

}
