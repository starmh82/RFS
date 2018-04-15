using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFS.Core.Security
{
    public class IdentityUserRole : IRole<int>
    {
        public IdentityUserRole()
        {
            Claims = new List<IdentityRoleClaim>();
            Users = new List<IdentityUser>();
        }
        public IdentityUserRole(string roleName):this()
        {
            Name = roleName;
        }
        public virtual int Id { get; private set; }

        public virtual string Name { get; set; }
        public virtual ICollection<IdentityRoleClaim> Claims { get; private set; }
        public virtual ICollection<IdentityUser> Users { get; private set; }
    }
}
