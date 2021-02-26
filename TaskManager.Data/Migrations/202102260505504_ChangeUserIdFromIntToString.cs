namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIdFromIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activity", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activity", "UserId", c => c.Int(nullable: false));
        }
    }
}
