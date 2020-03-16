using OnlineMovieTicket.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineMovieTicket.Repository
{
    public class MovieRepository
    {
        public IEnumerable Index()
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                
                List<Movie> movie = database.MovieDetails.ToList();
                return movie;            }
        }
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

        public Movie Edit(int id)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                return database.MovieDetails.Find(id);
            }
        }
        public void EditMovie(Movie movie)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                database.Entry(movie).State = EntityState.Modified;
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
