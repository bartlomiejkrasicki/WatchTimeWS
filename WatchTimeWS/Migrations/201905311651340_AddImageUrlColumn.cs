namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "ImageUrl", c => c.String(maxLength: 600));
            AddColumn("dbo.Producers", "ImageUrl", c => c.String(maxLength: 600));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producers", "ImageUrl");
            DropColumn("dbo.Series", "ImageUrl");
        }
    }
}
