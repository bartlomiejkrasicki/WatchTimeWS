namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Role", c => c.String());
        }
    }
}
