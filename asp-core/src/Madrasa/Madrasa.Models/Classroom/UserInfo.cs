using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Models
{
    public class UserInfo
    {
        public string name { get; set; }
        public string userName { get; set; }
        public string connectionId { get; set; }
        public Boolean micOn { get; set; }
        public Boolean camOn { get; set; }      
    }
}
