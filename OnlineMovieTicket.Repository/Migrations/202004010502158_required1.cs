namespace OnlineMovieTicket.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Role", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Duration", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Duration", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Role", c => c.String());
        }
    }
}
