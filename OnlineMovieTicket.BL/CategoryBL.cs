using OnlineMovieTicket.Entity;
using System;
using System.Collections.Generic;
using OnlineMovieTicket.Repository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieTicket.BL
{
    public interface ICategoryBL
    {
        void AddCategory(Category category);
        IEnumerable<Category> CategoryDetails();
        Category Details(int id);
        void Delete(int id);
        void Update(Category category);
        Category GetCategory(int id);
    }
    public class CategoryBL : ICategoryBL
    {
        public CategoryRepository categoryRepository = new CategoryRepository();
        public void AddCategory(Category category)
        {
            categoryRepository.AddCategory(category);
        }

        public IEnumerable<Category> CategoryDetails()
        {
            return categoryRepository.CategoryDetails();
        }
        public Category Details(int id)
        {
            return categoryRepository.Details(id);
        }
        public void Delete(int id)
        {
             categoryRepository.Delete(id);
        }
        public void Update(Category category)
        {
            categoryRepository.Update(category);
        }
        public Category GetCategory(int id)
        {
            return categoryRepository.GetCategory(id);
        }
    }
}
