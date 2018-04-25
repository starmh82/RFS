namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 20));
            DropColumn("dbo.Users", "Title");
        }
    }
}
