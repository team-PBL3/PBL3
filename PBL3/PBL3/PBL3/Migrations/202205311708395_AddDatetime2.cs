namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatetime2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartDetails", "Time", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartDetails", "Time");
        }
    }
}
