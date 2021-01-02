using Madrasa.Shared.Generic;
using System.Collections.Generic;

namespace Madrasa.Models
{
    public class Grade : Entity<int>
    {
        public ICollection<Class> Classes { get; set; }
    }
}
