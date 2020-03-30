using OnlineMovieTicket.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMovieTicket.Repository
{

    public interface ICategoryRespository
    {
        void AddCategory(Category category);
        List<Category> CategoryDetails();
        Category Details(int id);
        void Delete(int id);
        void Update(Category category);
        Category GetCategory(int id);
    }
    public class CategoryRepository : ICategoryRespository
    {


        public void AddCategory(Category category)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                onlineMovieTicketDBContext.Categories.Add(category);
                onlineMovieTicketDBContext.SaveChanges();
            }

        }
        public List<Category> CategoryDetails()
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {

                List<Category> data = onlineMovieTicketDBContext.Categories.ToList();
                return data;
            }
        }
        public Category Details(int id)
        {
            using (OnlineMovieTicketDBContext database = new OnlineMovieTicketDBContext())
            {
                Category category = database.Categories.Find(id);
                return category;
            }
        }
        public void Delete(int id)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                Category category = onlineMovieTicketDBContext.Categories.Find(id);
                onlineMovieTicketDBContext.Categories.Remove(category);
                onlineMovieTicketDBContext.SaveChanges();


            }
        }

        public void Update(Category category)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {

                onlineMovieTicketDBContext.Entry(category).State = System.Data.Entity.EntityState.Modified;
                onlineMovieTicketDBContext.SaveChanges();
            }
        }

        public Category GetCategory(int id)
        {
            using (OnlineMovieTicketDBContext onlineMovieTicketDBContext = new OnlineMovieTicketDBContext())
            {
                return onlineMovieTicketDBContext.Categories.Where(category => category.CategoryId == id).FirstOrDefault();
            }
        }

    }


}
