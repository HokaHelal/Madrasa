using Madrasa.Shared.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Models
{
    public class Subject : Entity<int>
    {
        public ICollection<Teacher> Teachers { get; set; }
    }

}
