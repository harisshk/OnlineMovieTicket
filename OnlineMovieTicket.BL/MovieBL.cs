using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Repository;
using System.Collections;

namespace OnlineMovieTicket.BL
{
    public class MovieBL
    {
        public MovieRepository movieRepository = new MovieRepository();

        public IEnumerable Index()
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
