using Madrasa.Shared.Generic;

namespace Madrasa.Models
{
    public class Manager : BaseEntity
    {
        public Manager()
        {
        }
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
