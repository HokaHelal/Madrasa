using Madrasa.Shared.Generic;
using System;
using System.Collections.Generic;

namespace Madrasa.Models
{
    public class ForumBase : BaseEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public int AuthorId { get; set; }
        public AppUser Author { get; set; }
        public ICollection<AppUser> UserLikes { get; set; }
    }
}
