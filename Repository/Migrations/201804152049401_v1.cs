namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityRoles", newName: "Roles");
            RenameTable(name: "dbo.IdentityRoleClaims", newName: "RoleClaims");
            RenameTable(name: "dbo.IdentityUsers", newName: "Users");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "UserClaims");
            RenameTable(name: "dbo.IdentityUserLogins", newName: "UserLogins");
            RenameTable(name: "dbo.IdentityUserRoleIdentityUsers", newName: "UsersRoles");
            RenameColumn(table: "dbo.UsersRoles", name: "IdentityUserRole_Id", newName: "RoleID");
            RenameColumn(table: "dbo.UsersRoles", name: "IdentityUser_Id", newName: "UserID");
            RenameIndex(table: "dbo.UsersRoles", name: "IX_IdentityUser_Id", newName: "IX_UserID");
            RenameIndex(table: "dbo.UsersRoles", name: "IX_IdentityUserRole_Id", newName: "IX_RoleID");
            DropPrimaryKey("dbo.UsersRoles");
            AddPrimaryKey("dbo.UsersRoles", new[] { "UserID", "RoleID" });
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "IsActive", c => c.Boolean());
            DropPrimaryKey("dbo.UsersRoles");
            AddPrimaryKey("dbo.UsersRoles", new[] { "IdentityUserRole_Id", "IdentityUser_Id" });
            RenameIndex(table: "dbo.UsersRoles", name: "IX_RoleID", newName: "IX_IdentityUserRole_Id");
            RenameIndex(table: "dbo.UsersRoles", name: "IX_UserID", newName: "IX_IdentityUser_Id");
            RenameColumn(table: "dbo.UsersRoles", name: "UserID", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.UsersRoles", name: "RoleID", newName: "IdentityUserRole_Id");
            RenameTable(name: "dbo.UsersRoles", newName: "IdentityUserRoleIdentityUsers");
            RenameTable(name: "dbo.UserLogins", newName: "IdentityUserLogins");
            RenameTable(name: "dbo.UserClaims", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.Users", newName: "IdentityUsers");
            RenameTable(name: "dbo.RoleClaims", newName: "IdentityRoleClaims");
            RenameTable(name: "dbo.Roles", newName: "IdentityRoles");
        }
    }
}
