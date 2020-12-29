using Madrasa.Shared.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.API.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
