namespace CargillApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.EventLocs",
                c => new
                    {
                        EventLocID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        Location = c.String(),
                        IsComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventLocID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventLocs", "EventID", "dbo.Events");
            DropIndex("dbo.EventLocs", new[] { "EventID" });
            DropTable("dbo.EventLocs");
            DropTable("dbo.Events");
        }
    }
}
