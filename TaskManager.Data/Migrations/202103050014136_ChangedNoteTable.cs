namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNoteTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "TodoId", "dbo.Todo");
            DropIndex("dbo.Note", new[] { "TodoId" });
            AddColumn("dbo.Note", "ActivityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "ActivityId");
            AddForeignKey("dbo.Note", "ActivityId", "dbo.Activity", "ActivityId", cascadeDelete: true);
            DropColumn("dbo.Note", "TodoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "TodoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Note", "ActivityId", "dbo.Activity");
            DropIndex("dbo.Note", new[] { "ActivityId" });
            DropColumn("dbo.Note", "ActivityId");
            CreateIndex("dbo.Note", "TodoId");
            AddForeignKey("dbo.Note", "TodoId", "dbo.Todo", "TodoId", cascadeDelete: true);
        }
    }
}
