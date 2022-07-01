namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatistics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productid = c.Int(nullable: false),
                        income = c.Double(nullable: false),
                        pending = c.Double(nullable: false),
                        total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.productid, cascadeDelete: true)
                .Index(t => t.productid, anonymousArguments: new {Type="BTrees" });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statistics", "productid", "dbo.Products");
            DropIndex("dbo.Statistics", new[] { "productid" });
            DropTable("dbo.Statistics");
        }
    }
}
