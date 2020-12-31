using System;

namespace Madrasa.Dto
{
    public class StudentDto
    {
        public string name { get; set; }
        public string username { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime created { get; set; }
        public DateTime lastActive { get; set; }
        public string gender { get; set; }
        public string photoUrl { get; set; }
    }
}
