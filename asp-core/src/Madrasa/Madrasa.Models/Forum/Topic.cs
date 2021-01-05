using System.Collections;
using System.Collections.Generic;

namespace Madrasa.Models
{

    public class Topic : ForumBase
    {
        public Topic()
        {
        }

        public int SectionId { get; set; }
        public Section Section { get; set; }
        public bool IsPinned { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
