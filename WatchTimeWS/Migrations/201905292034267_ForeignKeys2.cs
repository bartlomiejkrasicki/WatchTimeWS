namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Description = c.String(),
                        YearOfEstablishment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Series", "Producer_Id", c => c.Int());
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Type", c => c.String(nullable: false));
            CreateIndex("dbo.Series", "Producer_Id");
            AddForeignKey("dbo.Series", "Producer_Id", "dbo.Producers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Series", "Producer_Id", "dbo.Producers");
            DropIndex("dbo.Series", new[] { "Producer_Id" });
            AlterColumn("dbo.Genres", "Type", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
            DropColumn("dbo.Series", "Producer_Id");
            DropTable("dbo.Producers");
        }
    }
}
