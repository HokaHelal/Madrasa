using System;
using System.Collections.Generic;

namespace Madrasa.Dto
{
    public class PostDetailDto
    {
        public int id { get; set; }
        public int topicId { get; set; }
        public string topicTitle { get; set; }
        public string topicAuthor { get; set; }
        public string content { get; set; }
        public int authorId { get; set; }
        public string authorName { get; set; }
        public string authorPhoto { get; set; }
        public DateTime created { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
    }
}
