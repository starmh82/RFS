namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "NationalID", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Users", "Mobile", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Users", "CompanyName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CompanyName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Mobile", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "NationalID", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String());
        }
    }
}
