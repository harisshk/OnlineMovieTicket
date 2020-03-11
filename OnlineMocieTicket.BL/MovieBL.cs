using OnlineMovieTicket.Entity;

namespace OnlineMovieTicket.BL
{
    public class MovieBL
    {
        MovieRepository movieRepository = new MovieRepository();

        public void DeleteMovie(int id)
        {
            movieRepository.DeleteMovie(id);
        } 
        public void CreateMovie(Movie movie)
        {
            movieRepository.AddMovie(movie);
        }
        public void EditMovie()
        {
            movieRepository.EditMovie();
        }
    }
}
