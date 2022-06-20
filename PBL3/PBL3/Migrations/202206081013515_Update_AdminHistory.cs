namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_AdminHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admin_Action_History", "impactedObjectTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admin_Action_History", "impactedObjectTypeId");
        }
    }
}
