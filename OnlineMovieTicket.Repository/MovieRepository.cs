using OnlineMovieTicket.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineMovieTicket.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        void AddMovie(Movie movie);
        void DeleteMovie(int movieId);
        Movie GetMovieId(int id);
        void UpdateMovie(Movie movie);
      
    }
    public class MovieRepository:IMovieRepository
    {
        
        public List<Movie> GetAllMovies() //Get all movies from Database.
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                
                List<Movie> movie = onlineMovieTicketDBContext.MovieDetails.ToList();
                return movie;        
            }
        }
        public void AddMovie(Movie movie) //Add movies to Database.
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                onlineMovieTicketDBContext.MovieDetails.Add(movie);
                onlineMovieTicketDBContext.SaveChanges();
            }
        }
      
        public void DeleteMovie(int movieId) //Delete movie from the database.
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                Movie movie = onlineMovieTicketDBContext.MovieDetails.Find(movieId);
                onlineMovieTicketDBContext.MovieDetails.Remove(movie);
                onlineMovieTicketDBContext.SaveChanges();
            }
        }

        public Movie GetMovieId(int id) //Get Id of the movie from the database.
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                return onlineMovieTicketDBContext.MovieDetails.Find(id);
            }
        }
        public void UpdateMovie(Movie movie) //Update the movie details to the database.
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                onlineMovieTicketDBContext.Entry(movie).State = EntityState.Modified;
                onlineMovieTicketDBContext.SaveChanges();
            }
        }
        
    }
    
}
