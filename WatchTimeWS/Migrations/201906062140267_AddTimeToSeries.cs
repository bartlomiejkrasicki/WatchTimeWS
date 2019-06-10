namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeToSeries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "Time", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Series", "Time");
        }
    }
}
