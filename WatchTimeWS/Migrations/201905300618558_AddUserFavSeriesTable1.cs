namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserFavSeriesTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavouriteSeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Series_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.Series_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Series_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavouriteSeries", "User_Id", "dbo.Users");
            DropForeignKey("dbo.FavouriteSeries", "Series_Id", "dbo.Series");
            DropIndex("dbo.FavouriteSeries", new[] { "User_Id" });
            DropIndex("dbo.FavouriteSeries", new[] { "Series_Id" });
            DropTable("dbo.FavouriteSeries");
        }
    }
}
