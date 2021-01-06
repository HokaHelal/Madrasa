using System;
using System.Collections.Generic;

namespace Madrasa.Dto
{
    public class TopicDetailDto
    {
        public int id { get; set; }
        public string sectionName { get; set; }
        public bool isPinned { get; set; }
        public string className { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int authorId { get; set; }
        public string authorName { get; set; }
        public string authorPhoto { get; set; }
        public DateTime created { get; set; }
        public ICollection<PostDetailDto> Posts { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
    }
}
