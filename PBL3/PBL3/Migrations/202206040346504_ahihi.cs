namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ahihi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "userid", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "phone", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.People", "email", c => c.String(unicode: false));
            CreateIndex("dbo.Payments", "userid",anonymousArguments:new { Type="BTrees"});
            AddForeignKey("dbo.Payments", "userid", "dbo.Users", "id", cascadeDelete: true);
            DropColumn("dbo.Orderdetails", "name");
            DropColumn("dbo.Orderrs", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orderrs", "name", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Orderdetails", "name", c => c.String(nullable: false, unicode: false));
            DropForeignKey("dbo.Payments", "userid", "dbo.Users");
            DropIndex("dbo.Payments", new[] { "userid" });
            AlterColumn("dbo.People", "email", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.People", "phone", c => c.Int(nullable: false));
            DropColumn("dbo.Payments", "userid");
        }
    }
}
