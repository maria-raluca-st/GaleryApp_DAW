using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication_proiect.DAL.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { set; get; }
        public virtual Role Role { set; get; }
    }
}
