using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFS.Core;
using RFS.Core.Security;
using System;

namespace RFS.RepositoriesCore
{
    public class RFSContext : DbContext
    {
        public RFSContext(DbContextOptions<RFSContext> options): base(options)
        {
        }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<IdentityUser> Users { get; set; }

        #region Identity
        public virtual DbSet<IdentityUserClaim> UserClaims { get; set; }
        public virtual DbSet<IdentityUserLogin> UserLogins { get; set; }
        public virtual DbSet<IdentityRoleClaim> RoleClaims { get; set; }
        public virtual DbSet<IdentityRole> Roles { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().MapToStoredProcedures();   // to create stored pocedures and use it in savecontext
            //modelBuilder.Entity<User>().Property(p => p.RowVersion).IsConcurrencyToken(); // to set timestamp for this column

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins")
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
                //.HasMany(u => u.Roles)
                //.WithMany(r => r.Users)
                //.Map(x =>
                //{
                //    x.MapLeftKey("UserID");
                //    x.MapRightKey("RoleID");
                //    x.ToTable("UsersRoles");
                //});

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityRoleClaim>()
                .ToTable("RoleClaims");

            base.OnModelCreating(modelBuilder);
        }
       
    }
}
