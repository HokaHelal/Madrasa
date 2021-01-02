﻿using Microsoft.AspNetCore.Identity;
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
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Manager> Managers { get; set; }
    }
}