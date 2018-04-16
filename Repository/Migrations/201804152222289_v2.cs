namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "NationalID", c => c.String(maxLength: 10));
            AddColumn("dbo.Users", "Mobile", c => c.String(maxLength: 10));
            AddColumn("dbo.Users", "CompanyName", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "LanguagePreferred", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "UserType", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CreatedByID", c => c.Int());
            AddColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UpdatedByID", c => c.Int());
            AddColumn("dbo.Users", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UpdatedAt");
            DropColumn("dbo.Users", "UpdatedByID");
            DropColumn("dbo.Users", "CreatedAt");
            DropColumn("dbo.Users", "CreatedByID");
            DropColumn("dbo.Users", "UserType");
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "LanguagePreferred");
            DropColumn("dbo.Users", "CompanyName");
            DropColumn("dbo.Users", "Mobile");
            DropColumn("dbo.Users", "NationalID");
            DropColumn("dbo.Users", "Name");
        }
    }
}
