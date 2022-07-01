namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Statistics", "period", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Statistics", "period");
        }
    }
}
