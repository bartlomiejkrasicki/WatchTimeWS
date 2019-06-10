namespace WatchTimeWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SeasonsNumber = c.Int(nullable: false),
                        YearOfProduction = c.Int(nullable: false),
                        Description = c.String(maxLength: 400),
                        Authors_Id = c.Int(),
                        Genres_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Authors_Id)
                .ForeignKey("dbo.Genres", t => t.Genres_Id)
                .Index(t => t.Authors_Id)
                .Index(t => t.Genres_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 40),
                        Login = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 40),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Series", "Genres_Id", "dbo.Genres");
            DropForeignKey("dbo.Series", "Authors_Id", "dbo.Authors");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.Series", new[] { "Genres_Id" });
            DropIndex("dbo.Series", new[] { "Authors_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Series");
            DropTable("dbo.Genres");
            DropTable("dbo.Authors");
        }
    }
}
