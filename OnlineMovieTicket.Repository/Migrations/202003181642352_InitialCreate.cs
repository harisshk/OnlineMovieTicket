namespace OnlineMovieTicket.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 20),
                        Discription = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        ShowTimeMorning = c.String(),
                        ShowTimeAfternoon = c.String(),
                        ShowTimeEvening = c.String(),
                        Price = c.Double(nullable: false),
                        Duration = c.String(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "Category_CategoryId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Categories");
            DropTable("dbo.Accounts");
        }
    }
}
