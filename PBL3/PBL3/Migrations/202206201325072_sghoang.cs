namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sghoang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orderrs", "personid", c => c.Int(nullable: false));
            CreateIndex("dbo.Orderrs", "personid", anonymousArguments: new { Type = "BTrees" });
            AddForeignKey("dbo.Orderrs", "personid", "dbo.People", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orderrs", "personid", "dbo.People");
            DropIndex("dbo.Orderrs", new[] { "personid" });
            DropColumn("dbo.Orderrs", "personid");
        }
    }
}
