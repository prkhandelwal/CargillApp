namespace CargillApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig180703 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventUsers",
                c => new
                    {
                        EventUserID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                        Acknowledge = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventUserID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventUsers", "UserID", "dbo.Users");
            DropForeignKey("dbo.EventUsers", "EventID", "dbo.Events");
            DropIndex("dbo.EventUsers", new[] { "EventID" });
            DropIndex("dbo.EventUsers", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.EventUsers");
        }
    }
}
