namespace OnlineMovieTicket.Repository.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineMovieTicket.Repository.OnlineMovieTicketDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OnlineMovieTicket.Repository.DatabaseContext";
        }

        protected override void Seed(OnlineMovieTicket.Repository.OnlineMovieTicketDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
