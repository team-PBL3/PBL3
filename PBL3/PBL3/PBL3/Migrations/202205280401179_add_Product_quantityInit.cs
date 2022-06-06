namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Product_quantityInit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "quantityInit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "quantityInit");
        }
    }
}
