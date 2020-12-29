using Madrasa.Shared.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.API.Models
{
    public class Class : Entity<int>
    {
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
