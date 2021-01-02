using Madrasa.Shared.Generic;

namespace Madrasa.Models
{
    public class Class : Entity<int>
    {
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
