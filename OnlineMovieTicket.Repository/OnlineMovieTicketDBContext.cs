using OnlineMovieTicket.Entity;
using System.Data.Entity;

namespace OnlineMovieTicket.Repository
{
    public class OnlineMovieTicketDBContext : DbContext
    {

        public OnlineMovieTicketDBContext() : base("DatabaseContext") { }
        public DbSet<Account> AccountDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> MovieDetails { get; set; }

    }
}
