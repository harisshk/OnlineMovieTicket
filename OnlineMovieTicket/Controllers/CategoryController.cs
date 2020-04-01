using AutoMapper;
using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Filter.ExceptionFilterInMVC.Models;
using OnlineMovieTicket.Models;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    [LogCustomExceptionFilter]
    [CustomAuthorization]
    public class CategoryController : Controller
    {
        readonly CategoryBL categoryBL;
        public CategoryController() //Constructor.
        {
            categoryBL = new CategoryBL(); //Creating object to access CategoryBL class.
        }

        public ActionResult CategoryDetails() // GET Category
        {
            var categories = categoryBL.CategoryDetails(); //Method call to Category BL
            return View(categories);
        }

        public ActionResult AddCategory() //Add Category [GET]
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        internal ActionResult AddCategory(CategoryModel categoryModel) //Add Category [POST]
        {
            if (ModelState.IsValid)
            {
                //Auto Mapper.
                var mapCategory = new MapperConfiguration(configExpression => { configExpression.CreateMap<CategoryModel, Category>(); });
                IMapper mapper = mapCategory.CreateMapper();
                var category = mapper.Map<CategoryModel, Category>(categoryModel);
                categoryBL.AddCategory(category); //Method call to add category
                return RedirectToAction("Index", "Movie");
            }
            return View();
        }
    }
}