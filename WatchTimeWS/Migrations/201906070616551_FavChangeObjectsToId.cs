namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavChangeObjectsToId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavouriteSeries", "Series_Id", "dbo.Series");
            DropForeignKey("dbo.FavouriteSeries", "User_Id", "dbo.Users");
            DropIndex("dbo.FavouriteSeries", new[] { "Series_Id" });
            DropIndex("dbo.FavouriteSeries", new[] { "User_Id" });
            AddColumn("dbo.FavouriteSeries", "SeriesId", c => c.Int(nullable: false));
            AddColumn("dbo.FavouriteSeries", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.FavouriteSeries", "Series_Id");
            DropColumn("dbo.FavouriteSeries", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FavouriteSeries", "User_Id", c => c.Int());
            AddColumn("dbo.FavouriteSeries", "Series_Id", c => c.Int());
            DropColumn("dbo.FavouriteSeries", "UserId");
            DropColumn("dbo.FavouriteSeries", "SeriesId");
            CreateIndex("dbo.FavouriteSeries", "User_Id");
            CreateIndex("dbo.FavouriteSeries", "Series_Id");
            AddForeignKey("dbo.FavouriteSeries", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.FavouriteSeries", "Series_Id", "dbo.Series", "Id");
        }
    }
}
