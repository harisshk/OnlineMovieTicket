using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Repository;
using System.Collections.Generic;

namespace OnlineMovieTicket.BL
{
    public interface IMovieBL
    {
        List<Movie> GetAllMovies();
        void DeleteMovie(int id);
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        Movie GetMovieId(int id);
      
    }
    public class MovieBL:IMovieBL
    {
        public MovieRepository movieRepository = new MovieRepository();

        public List<Movie> GetAllMovies()
        {
            return movieRepository.GetAllMovies();
        }
        public void DeleteMovie(int id)
        {
            movieRepository.DeleteMovie(id);
        }
        public void CreateMovie(Movie movie)
        {
            movieRepository.AddMovie(movie);
        }
        public void UpdateMovie(Movie movie)
        {
            movieRepository.UpdateMovie(movie);
        }
        public Movie GetMovieId(int id)
        {
            return movieRepository.GetMovieId(id);
        }
    }
}
