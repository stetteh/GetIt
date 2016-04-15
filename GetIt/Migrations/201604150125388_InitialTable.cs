namespace GetIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Body = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        Upvote = c.Int(nullable: false),
                        Downvote = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Body = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                        Upvote = c.Int(nullable: false),
                        Downvote = c.Int(nullable: false),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
        }
    }
}
