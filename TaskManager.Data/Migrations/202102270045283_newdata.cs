namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "ActivityId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Note", "ActivityId");
        }
    }
}
