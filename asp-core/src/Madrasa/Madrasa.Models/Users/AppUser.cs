using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Madrasa.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public int RoleId { get; set; }
        public AppRole UserRoles { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Topic> TopicsLiked { get; set; }
        public ICollection<Post> PostsLiked { get; set; }
    }
}
