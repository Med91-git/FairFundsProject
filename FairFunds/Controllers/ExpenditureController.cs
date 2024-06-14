using FairFunds.Data;
using FairFunds.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Microsoft.AspNetCore.Identity;

namespace FairFunds.Controllers
{
    public class ExpenditureController : Controller
    {
        private readonly ApplicationDbContext _context;



        public ExpenditureController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("/[controller]/AddExpenditure")]
        public IActionResult AddExpenditure(Expenditure expenditure)
        {
            List<CustomUser> users = _context.Users.ToList();
            List<Category> categories = _context.Categories.ToList();
            ViewBag.Users = users;
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
