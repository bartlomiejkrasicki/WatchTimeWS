namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Series", "Authors_Id", "dbo.Authors");
            DropForeignKey("dbo.Series", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Series", new[] { "Authors_Id" });
            DropIndex("dbo.Series", new[] { "Genres_Id" });
            AddColumn("dbo.Authors", "Series_Id", c => c.Int());
            AddColumn("dbo.Genres", "Series_Id", c => c.Int());
            CreateIndex("dbo.Authors", "Series_Id");
            CreateIndex("dbo.Genres", "Series_Id");
            AddForeignKey("dbo.Authors", "Series_Id", "dbo.Series", "Id");
            AddForeignKey("dbo.Genres", "Series_Id", "dbo.Series", "Id");
            DropColumn("dbo.Series", "Authors_Id");
            DropColumn("dbo.Series", "Genres_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "Genres_Id", c => c.Int());
            AddColumn("dbo.Series", "Authors_Id", c => c.Int());
            DropForeignKey("dbo.Genres", "Series_Id", "dbo.Series");
            DropForeignKey("dbo.Authors", "Series_Id", "dbo.Series");
            DropIndex("dbo.Genres", new[] { "Series_Id" });
            DropIndex("dbo.Authors", new[] { "Series_Id" });
            DropColumn("dbo.Genres", "Series_Id");
            DropColumn("dbo.Authors", "Series_Id");
            CreateIndex("dbo.Series", "Genres_Id");
            CreateIndex("dbo.Series", "Authors_Id");
            AddForeignKey("dbo.Series", "Genres_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Series", "Authors_Id", "dbo.Authors", "Id");
        }
    }
}
