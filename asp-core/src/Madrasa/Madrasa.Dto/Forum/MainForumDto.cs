using System.Collections.Generic;

namespace Madrasa.Dto
{
    public class MainForumDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int orderNum { get; set; }
        public IEnumerable<TopicMainDto> topics { get; set; }
    }
}
