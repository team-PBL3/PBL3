namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ahihi : DbMigration
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
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.CreateBy)
                .ForeignKey("dbo.Users", t => t.EditBy)
                .Index(t => t.CreateBy, anonymousArguments: new { Type = "BTrees" })
                .Index(t => t.EditBy, anonymousArguments: new { Type = "BTrees" });

            AddColumn("dbo.CartDetails", "Time", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Orderrs", "TimeConfirm", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Orderrs", "TimeUpdate", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Orderdetails", "Time", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Orderdetails", "name", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admin_Action_History", "user_id", "dbo.Users");
            DropIndex("dbo.Admin_Action_History", new[] { "user_id" });
            AlterColumn("dbo.Orderdetails", "name", c => c.String(unicode: false));
            DropColumn("dbo.Orderdetails", "Time");
            DropColumn("dbo.Orderrs", "TimeUpdate");
            DropColumn("dbo.Orderrs", "TimeConfirm");
            DropColumn("dbo.CartDetails", "Time");
            DropTable("dbo.Admin_Action_History");
        }
    }
}
