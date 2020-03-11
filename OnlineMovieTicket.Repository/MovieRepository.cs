using OnlineMovieTicket.Entity;
using System.Data.Entity;
namespace OnlineMovieTicket.Repository
{
    public class MovieRepository
    {
       
        public void AddMovie(Movie movie)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                database.MovieDetails.Add(movie);
                database.SaveChanges();
            }
        }
      
        public void DeleteMovie(int movieId)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                Movie movie = database.MovieDetails.Find(movieId);
                database.MovieDetails.Remove(movie);
                database.SaveChanges();
            }
        }
        public void EditMovie(int movieId)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                Movie movie = database.MovieDetails.Find(movieId);
                database.MovieDetails.Remove(movie);
                database.SaveChanges();
            }
        }
    }
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("DatabaseContext") { }
        public DbSet<Account> AccountDetail { get; set; }
        
        public DbSet<Movie> MovieDetails { get; set; }
        
    }
}
