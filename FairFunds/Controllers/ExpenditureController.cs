using FairFunds.Data;
using FairFunds.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FairFunds.Controllers
{
    public class ExpenditureController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<CustomUser> _userManager;

        public ExpenditureController(ApplicationDbContext context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("/[controller]/AddExpenditure")]
        public IActionResult AddExpenditure()
        {
            // Assign each category field in the view (Manage expenditure entity foreign key)  
            LoadCategories();

            var claimsIdentity = (ClaimsIdentity)User.Identity; 
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            Expenditure e = new Expenditure();
            e.customuserId = userId;

            return View(e);
        }

        [HttpPost("/[controller]/AddExpenditure")]
        public IActionResult AddExpenditure(Expenditure expenditure)
        {
            // facultatif, au cas où l'utilisateur modifie l'id dans le formulaire dans son navigateur
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            expenditure.customuserId = userId;

            if (ModelState.IsValid)
            {
                _context.Expenditures.Add(expenditure);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            LoadCategories();
            return View(expenditure);
        }

        private void LoadCategories()
        {
            IEnumerable<SelectListItem> categories = _context.Categories.ToList().Select((c) => new SelectListItem
            { Text = c.Name, Value = c.CategoryID.ToString() });

            ViewBag.Categories = categories;
        }

        [Route("/[controller]/Index")]
        public IActionResult Index()
        {
            List<Expenditure> expenditureList = _context.Expenditures.Include((expenditure) => expenditure.Category).ToList(); 

            return View(expenditureList); 
        }

		[HttpGet("/[controller]/UpdateExpenditure/")]  
		public IActionResult UpdateExpenditure(int id) 

		{
            LoadCategories();

            // Searching in list the expenditure to update by id value

            foreach (Expenditure expenditure in _context.Expenditures)
			{
				if (expenditure.ExpenditureID == id) 
				{
					// Display the view with the expenditure selected by user 

					return View(expenditure);  
				}
			}

			return RedirectToAction("Index"); 
		}

		[HttpPost,ActionName("UpdateExpenditure")] 
		public IActionResult UpdateExpenditureCategoryP(int expenditureID, int categoryId)  
		{
            LoadCategories();

            // In category list, pick up the category the user wants to update 

            Category categoryToUpdate = _context.Categories.FirstOrDefault(c => c.CategoryID == categoryId);


            // In expenditure list, pick up the expenditure the user wants to update 

            Expenditure expenditureToUpdate = _context.Expenditures.Find(expenditureID);  

            // Assign the new category to the expenditure and update in database

            if (categoryToUpdate != null) 
            {
                expenditureToUpdate.CategoryID = categoryToUpdate.CategoryID;  
                _context.Update(expenditureToUpdate);
                _context.SaveChanges();

            }

            return RedirectToAction("Index");  

		}




	}
}
