namespace Madrasa.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
