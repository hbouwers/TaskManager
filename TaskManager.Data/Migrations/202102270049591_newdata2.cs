namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Note", "ActivityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "ActivityId", c => c.Int(nullable: false));
        }
    }
}
