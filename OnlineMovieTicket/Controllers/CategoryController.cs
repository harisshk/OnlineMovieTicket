using AutoMapper;
using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using OnlineMovieTicket.Models;
using System.Web.Mvc;

namespace OnlineMovieTicket.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        public CategoryBL categoryBL;
            public CategoryController()
        {
            categoryBL = new CategoryBL();
        }

        // GET: Category
        public ActionResult CategoryDetails()
        {
            var category=categoryBL.CategoryDetails();
            return View(category);
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryModel categoryModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var mapCategory = new MapperConfiguration(configExpression => { configExpression.CreateMap<CategoryModel, Category>(); });
                    IMapper mapper = mapCategory.CreateMapper();
                    var category = mapper.Map<CategoryModel, Category>(categoryModel);

                    categoryBL.AddCategory(category);
                    return RedirectToAction("Index", "Movie");
                }
            }
            catch
            {
                return View("Error");
            }
            return View();
        }
    }
}