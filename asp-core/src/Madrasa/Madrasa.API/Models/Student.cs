using Madrasa.Shared.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
