namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeriesTimeToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SeriesTime", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "SeriesTime");
        }
    }
}
