using System.Collections.Generic;

namespace Madrasa.Dto
{
    public class SectionDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public IEnumerable<TopicMainDto> topics { get; set; }
    }
}
