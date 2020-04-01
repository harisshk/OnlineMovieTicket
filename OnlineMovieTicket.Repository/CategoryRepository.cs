using OnlineMovieTicket.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMovieTicket.Repository
{
    public interface ICategoryRespository
    {
        void AddCategory(Category category);
        IEnumerable<Category> CategoryDetails();
        
    }
    public class CategoryRepository : ICategoryRespository
    {
        public void AddCategory(Category category)   //Add Category .
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                onlineMovieTicketDBContext.Categories.Add(category);
                onlineMovieTicketDBContext.SaveChanges();
            }

        }
        public IEnumerable<Category> CategoryDetails()   //Fetch Category from Database.
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {

              return onlineMovieTicketDBContext.Categories.ToList(); ;
               
            }
        }
       
    }
}
