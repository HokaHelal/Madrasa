using System;

namespace Madrasa.Dto
{
    public class TopicMainDto
    {
        public int id { get; set; }
        public bool isPinned { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int authorId { get; set; }
        public string authorName { get; set; }
        public string authorPhoto { get; set; }
        public DateTime created { get; set; }

    }
}
