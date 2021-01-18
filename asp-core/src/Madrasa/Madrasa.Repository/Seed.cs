using Madrasa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Madrasa.Repository
{
    public static class Seed
    {
        public static async Task SeedLookups(DataContext ctx)
        {
            var grades = new List<Grade>
            {
                new Grade() {Name = "P-1"},
                new Grade() {Name = "P-2"},
            };
            var classes = new List<Class>
            {
                new Class() { Name = "1-A", GradeId = 1},
                new Class() { Name = "1-B", GradeId = 1},
                new Class() { Name = "1-C", GradeId = 1},
                new Class() { Name = "2-A", GradeId = 2},
                new Class() { Name = "2-B", GradeId = 2},
                new Class() { Name = "2-C", GradeId = 2},
            };

            await ctx.Grades.AddRangeAsync(grades);
            await ctx.SaveChangesAsync();

            await ctx.Classes.AddRangeAsync(classes);
            await ctx.SaveChangesAsync();
        }

        public static async Task SeedForum(DataContext ctx)
        {
            if (await ctx.Topics.AnyAsync()) return;
            var fileName = "/Data/ForumSeedData.json";
            var forumData = await System.IO.File.ReadAllTextAsync(fileName);

            var topics = JsonSerializer.Deserialize<List<Topic>>(forumData);
            if (topics == null) return;

            var sections = new List<Section>
            {
                new Section() { Name = "General", OrderNum = 1, ClassId = 1 },
                new Section() { Name = "Math", OrderNum = 2, ClassId = 1 },
                new Section() { Name = "Science", OrderNum = 3, ClassId = 1 },
                new Section() { Name = "Fun", OrderNum = 4, ClassId = 1 }
            };

            await ctx.Sections.AddRangeAsync(sections);
            await ctx.SaveChangesAsync();

            await ctx.Topics.AddRangeAsync(topics);
            await ctx.SaveChangesAsync();        
    }

        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, DataContext ctx)
        {
            if (await userManager.Users.AnyAsync()) return;
            var fileName =  "/Data/UserSeedData.json";
            var userData = await System.IO.File.ReadAllTextAsync(fileName);

            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if (users == null) return;

            var roles = new List<AppRole>
            {
               new AppRole() { Name = "Student", RoleCode = 1},
               new AppRole() { Name = "Teacher", RoleCode = 2},
               new AppRole() { Name = "Manager", RoleCode = 3},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var students = new List<Student>();
            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                user.RoleId = 1;
                var result = await userManager.CreateAsync(user, "Password");
                await userManager.AddToRoleAsync(user, "Student");
                var student = new Student()
                {
                    AppUserId = user.Id,
                    ClassId = 1
                };

                students.Add(student);
            }

            await ctx.Students.AddRangeAsync(students);
            await ctx.SaveChangesAsync();
        }
    }
}
