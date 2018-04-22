using RFS.Core.Security;
using RFS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFS.Core.Enums;

namespace RFS.Repositories
{
    public class UserRepository : Repository<IdentityUser>
    {
        public UserRepository():base(new RFSContext())
        {
        }

        public RFSContext RFSContext
        { get { return context as RFSContext; } }

        public List<IdentityUser> GetAllEmployees()
        {
            return RFSContext.Users.Where(u => u.UserType == UserType.Employee).ToList();
        }
        public List<IdentityUser> GetAllClients()
        {
            return RFSContext.Users.Where(u => u.UserType == UserType.Client).ToList();
        }

    }
}
