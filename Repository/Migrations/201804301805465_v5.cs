namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeletionReasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        Type = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeletionRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MemberShipNo = c.String(nullable: false, maxLength: 20),
                        MemberName = c.String(nullable: false, maxLength: 50),
                        DeletionDate = c.DateTime(nullable: false),
                        Nationality = c.Int(nullable: false),
                        DeletionReasonId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedByID = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedByID = c.Int(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DeletionReasons", t => t.DeletionReasonId, cascadeDelete: true)
                .Index(t => t.DeletionReasonId);
            
            DropTable("dbo.Requests");
        }
        
        public override void Down()
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
            
            DropForeignKey("dbo.DeletionRequests", "DeletionReasonId", "dbo.DeletionReasons");
            DropIndex("dbo.DeletionRequests", new[] { "DeletionReasonId" });
            DropTable("dbo.DeletionRequests");
            DropTable("dbo.DeletionReasons");
        }
    }
}
