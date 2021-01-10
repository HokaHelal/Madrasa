using System.Collections.Generic;

namespace Madrasa.Dto
{
    public class SectionDto : SectionMainDto
    {
        public IEnumerable<TopicMainDto> topics { get; set; }
    }
}
