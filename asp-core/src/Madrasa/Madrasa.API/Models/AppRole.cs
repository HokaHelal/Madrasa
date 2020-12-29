using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Madrasa.API.Models
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUser> Users { get; set; }
        public int RoleCode { get; set; }
    }
}