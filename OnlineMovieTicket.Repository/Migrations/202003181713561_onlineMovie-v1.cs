namespace OnlineMovieTicket.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onlineMoviev1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "Category_CategoryId" });
            RenameColumn(table: "dbo.Movies", name: "Category_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Movies", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "CategoryId");
            AddForeignKey("dbo.Movies", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "CategoryId" });
            AlterColumn("dbo.Movies", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "CategoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.Movies", "Category_CategoryId");
            AddForeignKey("dbo.Movies", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
