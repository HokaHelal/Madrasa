using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Dto
{
    public class NewTopicDto
    {
        public int sectionId { get; set; }
        public bool isPinned { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int authorId { get; set; }
    }
}
