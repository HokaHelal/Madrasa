using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Dto.Classroom
{
    public class UserClass
    {
        public string  connectionId { get; set; }
        public string  name { get; set; }
        public string  username { get; set; }
        public bool micOn { get; set; }
        public bool camOn { get; set; }
    }
}
