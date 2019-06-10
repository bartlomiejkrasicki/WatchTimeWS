namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeSeries : DbMigration
    {
        public override void Up()
        {
            var time = new TimeSpan(3, 1, 0, 0, 0);
            Sql("update Series set Time = " + time.Ticks + " where id = 3");
            time = new TimeSpan(3, 8, 0, 0, 0);
            Sql("update Series set Time = " + time.Ticks + " where id = 6");
            time = new TimeSpan(3, 19, 41, 0, 0);
            Sql("update Series set Time = " + time.Ticks + " where id = 7");
            time = new TimeSpan(2, 21, 0, 0, 0);
            Sql("update Series set Time = " + time.Ticks + " where id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
