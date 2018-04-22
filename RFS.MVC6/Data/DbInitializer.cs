using RFS.Core.Security;
using RFS.RepositoriesCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFS.MVC6.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RFSContext context)
        {
            context.Database.EnsureCreated();

            if(context.Users.Any())
            {
                return;
            }

            for(int i=0;i<10000;i++)
            {
                IdentityUser user = new IdentityUser{ CompanyName="Bupa", Email="mahmoud"+i+"@hotmail.com", IsActive=true, LanguagePreferred=0, Mobile="0555555555", Name="MAhmoud Hazouri"+i, NationalID=i.ToString(), Password="123456", UserType= Core.Enums.UserType.Employee, UserName="mahmoud"+i  };
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
