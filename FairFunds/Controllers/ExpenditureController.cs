using FairFunds.Data;
using FairFunds.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

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

        [Route("/[controller]/AddExpenditure")]
        public IActionResult AddExpenditure(Expenditure expenditure) 
        {

            // Assign each category field in the view (Manage expenditure entity foreign key)  

            IEnumerable<SelectListItem> categories = _context.Categories.ToList().Select((c)=> new SelectListItem
            { Text =c.Name, Value = c.CategoryID.ToString()}); 
            
            ViewBag.Categories = categories; 

            /*// Recuperate the connected user

            ClaimsPrincipal currentUser = User;

            // Recuperate the connected custom user id

            var userId = _userManager.GetUserId(currentUser);*/


            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


            // Assign the custom user value in foreign key field of expenditure table in database (link between expenditure table and custom user table)

            expenditure.customuserId = userId;
            

            if (ModelState.IsValid)
            {

                _context.Expenditures.Add(expenditure);
                _context.SaveChanges();
                return RedirectToAction("Index");  
            }
            return View();
        }

        [Route("/[controller]/Index")]
        public IActionResult Index()
        {
            List<Expenditure> expenditureList = _context.Expenditures.Select((expenditure) => expenditure).ToList();

            return View(expenditureList);
        }







    }
}
