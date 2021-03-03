namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTodo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "NoteId", "dbo.Activity");
            DropIndex("dbo.Note", new[] { "NoteId" });
            DropPrimaryKey("dbo.Note");
            AddColumn("dbo.Activity", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Note", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Note", "TodoId", c => c.Int(nullable: false));
            AddColumn("dbo.Todo", "ActivityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Note", "NoteId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Todo", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Note", "NoteId");
            CreateIndex("dbo.Note", "TodoId");
            CreateIndex("dbo.Todo", "ActivityId");
            AddForeignKey("dbo.Todo", "ActivityId", "dbo.Activity", "ActivityId", cascadeDelete: true);
            AddForeignKey("dbo.Note", "TodoId", "dbo.Todo", "TodoId", cascadeDelete: true);
            DropColumn("dbo.Category", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "UserId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Note", "TodoId", "dbo.Todo");
            DropForeignKey("dbo.Todo", "ActivityId", "dbo.Activity");
            DropIndex("dbo.Todo", new[] { "ActivityId" });
            DropIndex("dbo.Note", new[] { "TodoId" });
            DropPrimaryKey("dbo.Note");
            AlterColumn("dbo.Todo", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Note", "NoteId", c => c.Int(nullable: false));
            DropColumn("dbo.Todo", "ActivityId");
            DropColumn("dbo.Note", "TodoId");
            DropColumn("dbo.Note", "UserId");
            DropColumn("dbo.Activity", "UserId");
            AddPrimaryKey("dbo.Note", "NoteId");
            CreateIndex("dbo.Note", "NoteId");
            AddForeignKey("dbo.Note", "NoteId", "dbo.Activity", "ActivityId");
        }
    }
}
