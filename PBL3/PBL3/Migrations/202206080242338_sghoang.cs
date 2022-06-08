namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sghoang : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "userid", "dbo.Users");
            DropForeignKey("dbo.Admin_Action_History", "user_id", "dbo.Users");
            DropIndex("dbo.Admin_Action_History", new[] { "user_id" });
            DropIndex("dbo.Payments", new[] { "userid" });
            AddColumn("dbo.Orderdetails", "name", c => c.String(unicode: false));
            AddColumn("dbo.Orderrs", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Users", "status", c => c.String(unicode: false));
            AlterColumn("dbo.Products", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Products", "description", c => c.String(unicode: false));
            AlterColumn("dbo.Products", "status", c => c.String(unicode: false));
            AlterColumn("dbo.Products", "infoproduct", c => c.String(unicode: false));
            AlterColumn("dbo.Categories", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Categories", "partofbody", c => c.String(unicode: false));
            AlterColumn("dbo.Images", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Orderrs", "status", c => c.String(unicode: false));
            AlterColumn("dbo.TradeMarks", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Roles", "value", c => c.String(unicode: false));
            AlterColumn("dbo.People", "name", c => c.String(unicode: false));
            AlterColumn("dbo.People", "sex", c => c.String(unicode: false));
            AlterColumn("dbo.People", "phone", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "address", c => c.String(unicode: false));
            DropColumn("dbo.CartDetails", "Time");
            DropColumn("dbo.Orderdetails", "Time");
            DropColumn("dbo.Orderrs", "TimeConfirm");
            DropColumn("dbo.Orderrs", "TimeUpdate");
            DropColumn("dbo.Payments", "userid");
            DropTable("dbo.Admin_Action_History");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Payments", "userid", c => c.Int(nullable: false));
            AddColumn("dbo.Orderrs", "TimeUpdate", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Orderrs", "TimeConfirm", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Orderdetails", "Time", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.CartDetails", "Time", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.People", "address", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.People", "phone", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.People", "sex", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.People", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Roles", "value", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.TradeMarks", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Orderrs", "status", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Images", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Categories", "partofbody", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Categories", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Products", "infoproduct", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Products", "status", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Products", "description", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Products", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Users", "status", c => c.String(nullable: false, unicode: false));
            DropColumn("dbo.Orderrs", "name");
            DropColumn("dbo.Orderdetails", "name");
            CreateIndex("dbo.Payments", "userid");
            CreateIndex("dbo.Admin_Action_History", "user_id");
            AddForeignKey("dbo.Admin_Action_History", "user_id", "dbo.Users", "id");
            AddForeignKey("dbo.Payments", "userid", "dbo.Users", "id", cascadeDelete: true);
        }
    }
}
