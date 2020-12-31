using System;

namespace Madrasa.Dto
{
    public class StudentDto
    {
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string photoUrl { get; set; }
    }
}
