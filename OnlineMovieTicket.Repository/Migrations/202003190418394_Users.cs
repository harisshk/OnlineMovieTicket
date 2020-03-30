namespace OnlineMovieTicket.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ShowTimeMorning", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "ShowTimeAfternoon", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "ShowTimeEvening", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ShowTimeEvening", c => c.String());
            AlterColumn("dbo.Movies", "ShowTimeAfternoon", c => c.String());
            AlterColumn("dbo.Movies", "ShowTimeMorning", c => c.String());
        }
    }
}
