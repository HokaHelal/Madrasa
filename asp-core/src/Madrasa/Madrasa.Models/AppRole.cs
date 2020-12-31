using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Models
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUser> Users { get; set; }
        public int RoleCode { get; set; }
    }

}
