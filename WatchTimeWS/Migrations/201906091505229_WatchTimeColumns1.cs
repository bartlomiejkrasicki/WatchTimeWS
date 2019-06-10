namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WatchTimeColumns1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "Time", c => c.Long(nullable: false));
            DropColumn("dbo.Series", "WatchedTime");
            DropColumn("dbo.Series", "ToWatch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "ToWatch", c => c.Long(nullable: false));
            AddColumn("dbo.Series", "WatchedTime", c => c.Long(nullable: false));
            DropColumn("dbo.Series", "Time");
        }
    }
}
