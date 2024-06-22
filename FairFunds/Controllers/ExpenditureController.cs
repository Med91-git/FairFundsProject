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
            IEnumerable<SelectListItem> categories = _context.Categories.ToList().Select((c)=> new SelectListItem
            { Text =c.Name, Value = c.CategoryID.ToString()});


            // Recupérer le user connecté 

            ClaimsPrincipal currentUser = User; 

            // Recupérer l'id du custom user connecté (piste  -> chercher classe Identity Usermanager + code chat GPT)

            string userId = _userManager.GetUserId(currentUser); 

            // Affecter id du custom user dans la variable customuserId FK (associer la table dépense à l'utilisateur connecté)  

            //var expenditureConnectedUserId = _context.Expenditures
            



            ViewBag.Categories = categories;
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
