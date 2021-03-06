﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Dto
{
    public class LoggedUserDto
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string roleCode { get; set; }
        public string photoUrl { get; set; }
        public string token { get; set; }
        public int classId { get; set; }
        public int age { get; set; }
    }
}
