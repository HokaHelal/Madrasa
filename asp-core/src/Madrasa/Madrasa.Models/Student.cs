using Madrasa.Shared.Generic;
using System;

namespace Madrasa.Models
{
    public class Student : Entity<int>
    {
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
    }
}
