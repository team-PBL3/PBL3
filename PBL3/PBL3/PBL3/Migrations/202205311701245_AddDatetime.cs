namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orderdetails", "Time", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Orderdetails", "name", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orderdetails", "name", c => c.String(unicode: false));
            DropColumn("dbo.Orderdetails", "Time");
        }
    }
}
