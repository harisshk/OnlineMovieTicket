using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Repository;
using System.Collections.Generic;

namespace OnlineMovieTicket.BL
{
    public interface IMovieBL
    {
        List<Movie> Index();
        void DeleteMovie(int id);
        void CreateMovie(Movie movie);
        void EditMovie(Movie movie);
        Movie Edit(int id);
    }
    public class MovieBL:IMovieBL
    {
        public MovieRepository movieRepository = new MovieRepository();

        public List<Movie> Index()
        {
            return movieRepository.Index();
        }
        public void DeleteMovie(int id)
        {
            movieRepository.DeleteMovie(id);
        }
        public void CreateMovie(Movie movie)
        {
            movieRepository.AddMovie(movie);
        }
        public void EditMovie(Movie movie)
        {
            movieRepository.EditMovie(movie);

        }
        public Movie Edit(int id)
        {
            return movieRepository.Edit(id);

        }
    }
}
