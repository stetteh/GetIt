namespace GetIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morestuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Body", c => c.String());
            AlterColumn("dbo.Comments", "Author", c => c.String());
        }
    }
}
