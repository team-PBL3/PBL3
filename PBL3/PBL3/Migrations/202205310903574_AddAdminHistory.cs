namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin_Action_History",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreateBy = c.Int(nullable: false),
                        EditBy = c.Int(nullable: false),
                        actionType = c.Int(nullable: false),
                        impactedObjectType = c.Int(nullable: false),
                        ActionTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.CreateBy)
                .ForeignKey("dbo.Users", t => t.EditBy)
                .Index(t => t.CreateBy, anonymousArguments: new { Type = "BTrees" })
                .Index(t => t.EditBy, anonymousArguments: new { Type = "BTrees" });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admin_Action_History", "user_id", "dbo.Users");
            DropIndex("dbo.Admin_Action_History", new[] { "user_id" });
            DropTable("dbo.Admin_Action_History");
        }
    }
}
