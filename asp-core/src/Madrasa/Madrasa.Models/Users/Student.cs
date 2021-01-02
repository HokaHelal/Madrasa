using Madrasa.Shared.Generic;

namespace Madrasa.Models
{
    public class Student : BaseEntity
    {
        public Student()
        {
        }
        public Student(int appUserId, int classId)
        {
            ClassId = classId;
            AppUserId = appUserId;
        }

        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
