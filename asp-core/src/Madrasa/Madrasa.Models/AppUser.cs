using Madrasa.Shared.Generic;
using Microsoft.AspNetCore.Identity;
using System;

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
    }
}
