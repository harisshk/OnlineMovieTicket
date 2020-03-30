using OnlineMovieTicket.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineMovieTicket.Repository
{
    public interface IMovieRepository
    {
        List<Movie> Index();
        void AddMovie(Movie movie);
        void DeleteMovie(int movieId);
        Movie Edit(int id);
        void EditMovie(Movie movie);
    }
    public class MovieRepository:IMovieRepository
    {
        public List<Movie> Index()
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                
                List<Movie> movie = onlineMovieTicketDBContext.MovieDetails.ToList();
                return movie;        
            }
        }
        public void AddMovie(Movie movie)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                onlineMovieTicketDBContext.MovieDetails.Add(movie);
                onlineMovieTicketDBContext.SaveChanges();
            }
        }
      
        public void DeleteMovie(int movieId)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                Movie movie = onlineMovieTicketDBContext.MovieDetails.Find(movieId);
                onlineMovieTicketDBContext.MovieDetails.Remove(movie);
                onlineMovieTicketDBContext.SaveChanges();
            }
        }

        public Movie Edit(int id)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                return onlineMovieTicketDBContext.MovieDetails.Find(id);
            }
        }
        public void EditMovie(Movie movie)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                onlineMovieTicketDBContext.Entry(movie).State = EntityState.Modified;
                onlineMovieTicketDBContext.SaveChanges();
            }
        }
        
    }
    
}
