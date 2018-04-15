using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFS.Core.Security
{
    public class IdentityUser : IUser<int>
    {
        public IdentityUser()
        {
            Roles = new List<IdentityUserRole>();
            Claims = new List<IdentityUserClaim>();
            Logins = new List<IdentityUserLogin>();
        }
        public IdentityUser(string userName):this()
        {
            UserName = userName;

        }

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        public virtual string Email { get; set; }

        /// <summary>
        ///     True if the email is confirmed, default is false
        /// </summary>
        //public  bool EmailConfirmed { get; set; }

        /// <summary>
        ///     The salted/hashed form of the user password
        /// </summary>
        //public  string PasswordHash { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// A random value that should change whenever a users credentials change (password changed, login removed)
        /// </summary>
       // public  string SecurityStamp { get; set; }

        /// <summary>
        /// A random value that should change whenever a user is persisted to the store
        /// </summary>
        //public  byte[] ConcurrencyStamp { get; set; }

        /// <summary>
        ///     PhoneNumber for the user
        /// </summary>
        //public  string PhoneNumber { get; set; }

        /// <summary>
        ///     True if the phone number is confirmed, default is false
        /// </summary>
       // public  bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        ///     Is two factor enabled for the user
        /// </summary>
        //public  bool TwoFactorEnabled { get; set; }

        /// <summary>
        ///     DateTime in UTC when lockout ends, any time in the past is considered not locked out.
        /// </summary>
        //public  DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        ///     Is lockout enabled for this user
        /// </summary>
        //public  bool LockoutEnabled { get; set; }

        /// <summary>
        ///     Used to record failures for the purposes of lockout
        /// </summary>
        //public  int AccessFailedCount { get; set; }

        /// <summary>
        ///     Navigation property for users in the role
        /// </summary>
        public  ICollection<IdentityUserRole> Roles { get; protected set; }

        /// <summary>
        ///     Navigation property for users claims
        /// </summary>
        public  ICollection<IdentityUserClaim> Claims { get; private set; }

        /// <summary>
        ///     Navigation property for users logins
        /// </summary>
        public  ICollection<IdentityUserLogin> Logins { get; private set; }
    }
}
