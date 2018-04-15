namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedByID = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoleClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityRole_Id = c.Int(),
                        IdentityUserRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.IdentityUserRoles", t => t.IdentityUserRole_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUserRole_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NormalizedName = c.String(),
                        ConcurrencyStamp = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.IdentityRole_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        ProviderDisplayName = c.String(),
                        UserId = c.Int(nullable: false),
                        IdentityUser_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.RoleID })
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUserRoles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "IdentityRole_Id", "dbo.Roles");
            DropForeignKey("dbo.UsersRoles", "RoleID", "dbo.IdentityUserRoles");
            DropForeignKey("dbo.UsersRoles", "UserID", "dbo.Users");
            DropForeignKey("dbo.RoleClaims", "IdentityUserRole_Id", "dbo.IdentityUserRoles");
            DropForeignKey("dbo.UserLogins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.RoleClaims", "IdentityRole_Id", "dbo.Roles");
            DropIndex("dbo.UsersRoles", new[] { "RoleID" });
            DropIndex("dbo.UsersRoles", new[] { "UserID" });
            DropIndex("dbo.UserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Users", new[] { "IdentityRole_Id" });
            DropIndex("dbo.RoleClaims", new[] { "IdentityUserRole_Id" });
            DropIndex("dbo.RoleClaims", new[] { "IdentityRole_Id" });
            DropTable("dbo.UsersRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.RoleClaims");
            DropTable("dbo.Requests");
        }
    }
}
