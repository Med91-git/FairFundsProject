using FairFunds.Data;
using FairFunds.Models;
using Microsoft.AspNetCore.Mvc;

namespace FairFunds.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;


        public CategoryController(ApplicationDbContext context)
        {
            _context = context; 
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(); 
        }
    }
}
