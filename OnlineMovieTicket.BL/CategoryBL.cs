using OnlineMovieTicket.Entity;
using System;
using System.Collections.Generic;
using OnlineMovieTicket.Repository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieTicket.BL
{
    public interface ICategoryBL //Interface in Category.
    {
        void AddCategory(Category category);
        IEnumerable<Category> CategoryDetails();
       
    }
    public class CategoryBL : ICategoryBL //Class derived from inteface.
    {
        public CategoryRepository categoryRepository = new CategoryRepository();
        public void AddCategory(Category category) //Add category.
        {
            categoryRepository.AddCategory(category);
        }

        public IEnumerable<Category> CategoryDetails() //Get category details
        {
            return categoryRepository.CategoryDetails();
        }
        
    }
}
