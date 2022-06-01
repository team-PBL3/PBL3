namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatetime3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orderrs", "TimeConfirm", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Orderrs", "TimeUpdate", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orderrs", "TimeUpdate");
            DropColumn("dbo.Orderrs", "TimeConfirm");
        }
    }
}
