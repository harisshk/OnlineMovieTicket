using System.Collections.Generic;
using System.Data.Entity;
namespace OnlineMovieTicket.Entity
{
    public class MovieRepository
    {
        public static List<Movie> movies = new List<Movie>();
        static MovieRepository()
        {
            movies.Add(new Movie { MovieName = "Bigil", MovieId = 1, ShowTime = "09:00 AM", Price = 150 });
            movies.Add(new Movie { MovieName = "Naan Sirithal", MovieId = 2, ShowTime = "12:15 PM", Price = 160 });
            movies.Add(new Movie { MovieName = "Pattas", MovieId = 3, ShowTime = "03:30 PM", Price = 140 });
        }
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
        public void DeleteMovie(int movieId)
        {
            Movie movie = GetMovieId(movieId);
            if (movie != null)
                movies.Remove(movie);
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
    }
}
