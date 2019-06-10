namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeasonTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeasonNumber = c.Int(nullable: false),
                        TimeOfDuration = c.Time(nullable: false, precision: 7),
                        Series_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.Series_Id)
                .Index(t => t.Series_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seasons", "Series_Id", "dbo.Series");
            DropIndex("dbo.Seasons", new[] { "Series_Id" });
            DropTable("dbo.Seasons");
        }
    }
}
