namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WatchTimeColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "WatchedTime", c => c.Long(nullable: false));
            AddColumn("dbo.Series", "ToWatch", c => c.Long(nullable: false));
            AddColumn("dbo.Users", "ToWatchTime", c => c.Long(nullable: false));
            AddColumn("dbo.Users", "WatchedTime", c => c.Long(nullable: false));
            DropColumn("dbo.Series", "Time");
            DropColumn("dbo.Users", "SeriesTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "SeriesTime", c => c.Long(nullable: false));
            AddColumn("dbo.Series", "Time", c => c.Long(nullable: false));
            DropColumn("dbo.Users", "WatchedTime");
            DropColumn("dbo.Users", "ToWatchTime");
            DropColumn("dbo.Series", "ToWatch");
            DropColumn("dbo.Series", "WatchedTime");
        }
    }
}
