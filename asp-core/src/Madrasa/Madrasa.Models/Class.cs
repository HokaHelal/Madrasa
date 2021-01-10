using Madrasa.Shared.Generic;
using System.Collections.Generic;

namespace Madrasa.Models
{
    public class Class : Entity<int>
    {
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
}
