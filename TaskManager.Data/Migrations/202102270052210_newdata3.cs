namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "TodoId", "dbo.Todo");
            DropIndex("dbo.Note", new[] { "TodoId" });
            DropColumn("dbo.Note", "TodoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "TodoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "TodoId");
            AddForeignKey("dbo.Note", "TodoId", "dbo.Todo", "TodoId", cascadeDelete: true);
        }
    }
}
