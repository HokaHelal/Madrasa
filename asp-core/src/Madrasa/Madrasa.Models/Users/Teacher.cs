using Madrasa.Shared.Generic;

namespace Madrasa.Models
{
    public class Teacher : BaseEntity
    {
        public Teacher()
        {
        }

        public Teacher(int appUserId, int subjectId)
        {
            AppUserId = appUserId;
            SubjectId = subjectId;
        }

        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
