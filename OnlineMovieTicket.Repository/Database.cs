using OnlineMovieTicket.Entity;
using System.Data.Entity;

namespace OnlineMovieTicket.Repository
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("DatabaseContext") { }
        public DbSet<Account> AccountDetail { get; set; }
        public DbSet<Movie> MovieDetails { get; set; }

    }
}
