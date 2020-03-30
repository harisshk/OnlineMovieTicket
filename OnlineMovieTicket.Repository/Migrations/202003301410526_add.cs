namespace OnlineMovieTicket.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Categories", "Discription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Discription", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Categories", "Description");
        }
    }
}
