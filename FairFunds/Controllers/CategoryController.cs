using FairFunds.Data;
using FairFunds.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FairFunds.Controllers
{
    
    public class CategoryController : Controller 
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context; 
        }
        
        [Route("/[controller]/CreateCategory")]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");  
                //return View();
            }

            return View();
        }

        [Route("/[controller]/Index")] 
        public IActionResult Index() 
        {
            List<Category> categoryList = _context.Categories.Select((category) => category).ToList();

            return View(categoryList);  
        }

        
        [Route("/[controller]/DeleteCategory/")]
        public IActionResult DeleteCategory(int id) 
        {
            // Searching in list the category to delete

            foreach (Category category in _context.Categories)
            {
                if (category.CategoryID == id)
                {
                    // Display the view with the category selected by user

                    return View(category);
                }
            }

            return RedirectToAction("Index"); 
        }

        //[HttpPost,ActionName("DeleteCategory")] 
        public IActionResult DeleteCategoryPost(int CategoryID) 
        {
            // In category list, pick up the category the user wants to delete

            Category categoryToDelete = _context.Categories.Where((category) => category.CategoryID == CategoryID).FirstOrDefault(); 
            
            if(categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);  
                _context.SaveChanges();
            }
                        
            return RedirectToAction("Index");

        }

    }
}
