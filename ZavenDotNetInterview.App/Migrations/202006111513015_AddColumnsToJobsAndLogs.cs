namespace ZavenDotNetInterview.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToJobsAndLogs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "LastUpdatedAt", c => c.DateTime());
            AddColumn("dbo.Jobs", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Jobs", "Attempts", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Name", c => c.String());
            DropColumn("dbo.Jobs", "Attempts");
            DropColumn("dbo.Jobs", "CreatedAt");
            DropColumn("dbo.Jobs", "LastUpdatedAt");
        }
    }
}
