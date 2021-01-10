using Madrasa.Shared.Generic;
using System.Collections.Generic;

namespace Madrasa.Models
{
    public class Section : Entity<int>
    {
        public int OrderNum { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}
