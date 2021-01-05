namespace Madrasa.Models
{
    public class Post : ForumBase
    {
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
