namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ValidationModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "status", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Orderrs", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Orderrs", "status", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Products", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Products", "description", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Products", "status", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Products", "infoproduct", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Categories", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Categories", "partofbody", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Images", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.TradeMarks", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Roles", "value", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.People", "name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.People", "sex", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.People", "address", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.People", "email", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "email", c => c.String(unicode: false));
            AlterColumn("dbo.People", "address", c => c.String(unicode: false));
            AlterColumn("dbo.People", "sex", c => c.String(unicode: false));
            AlterColumn("dbo.People", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Roles", "value", c => c.String(unicode: false));
            AlterColumn("dbo.TradeMarks", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Images", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Categories", "partofbody", c => c.String(unicode: false));
            AlterColumn("dbo.Categories", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Products", "infoproduct", c => c.String(unicode: false));
            AlterColumn("dbo.Products", "status", c => c.String(unicode: false));
            AlterColumn("dbo.Products", "description", c => c.String(unicode: false));
            AlterColumn("dbo.Products", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Orderrs", "status", c => c.String(unicode: false));
            AlterColumn("dbo.Orderrs", "name", c => c.String(unicode: false));
            AlterColumn("dbo.Users", "status", c => c.String(unicode: false));
        }
    }
}
