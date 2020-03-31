namespace OnlineMovieTicket.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "MovieName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Movies", "Duration", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Duration", c => c.String());
            AlterColumn("dbo.Movies", "MovieName", c => c.String());
            AlterColumn("dbo.Accounts", "Password", c => c.String());
            AlterColumn("dbo.Accounts", "Phone", c => c.String());
            AlterColumn("dbo.Accounts", "Email", c => c.String());
            AlterColumn("dbo.Accounts", "Gender", c => c.String());
            AlterColumn("dbo.Accounts", "Name", c => c.String());
        }
    }
}
