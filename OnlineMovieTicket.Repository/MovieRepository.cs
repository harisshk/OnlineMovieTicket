using System.Collections.Generic;
using System.Data.Entity;
namespace OnlineMovieTicket.Entity
{
    public class MovieRepository
    {
        public static List<Movie> movies = new List<Movie>();
        
        public IEnumerable<Movie> GetMovieDetails()
        {
            return movies;
        }
        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
        public Movie GetMovieId(int movieId)
        {
            return movies.Find(id => id.MovieId == movieId);
        }
        public static void DeleteMovie(int movieId)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                Movie movie = database.MovieDetails.Find(movieId);
                database.MovieDetails.Remove(movie);
                database.SaveChanges();
            }

        }
            public void EditMovieDetails(Movie movie)
        {
            Movie updateMovie = GetMovieId(movie.MovieId);
            updateMovie.ShowTime = movie.ShowTime;
            updateMovie.Price = movie.Price;
            updateMovie.MovieName = movie.MovieName;
        }
    }
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("DatabaseContext") { }
        public DbSet<Account> AccountDetail { get; set; }
        
        public DbSet<Movie> MovieDetails { get; set; }
        
    }
}
