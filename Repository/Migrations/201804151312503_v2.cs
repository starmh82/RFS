namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "IsActive", c => c.Boolean());
        }
    }
}
