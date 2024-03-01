using Microsoft.AspNetCore.Mvc;
using ExpenseManagement2.DataLayer;
using ExpenseManagement2.Models;

namespace ExpenseManagement2.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        public readonly DBContextExpMgt _context;

        public ExpenseCategoryController(DBContextExpMgt context)
        {
            _context = context;
        }


        // read

        public IActionResult Index()
        {
            IEnumerable<ExpenseCategoryEntity> ExpenseCategories = _context.ExpsenseCategories.ToList();
            
            return View(ExpenseCategories);
        }



        // create
        public IActionResult Create(ExpenseCategoryEntity expenseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.ExpsenseCategories.Add(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GetExpCatDetailsForUpdate

        // update
        public IActionResult GetExpCatDetailsForUpdate(int? Id)
        {
            var _ExpenseCatDetails = _context.ExpsenseCategories.Find(Id);

            if(_ExpenseCatDetails == null)
            {
                return NotFound();
            }
            return View(_ExpenseCatDetails);
        }


        [HttpPost]
        public IActionResult Update(ExpenseCategoryEntity expenseCatDetails)
        {
            if (ModelState.IsValid)
            {
                _context.ExpsenseCategories.Update(expenseCatDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }




        // GetExpCatDetailsForDelete

        // delete
        public IActionResult GetExpCatDetailsForDelete(int? Id)
        {
            var _ExpenseCatDetails = _context.ExpsenseCategories.Find(Id);

            if (_ExpenseCatDetails == null)
            {
                return NotFound();
            }
            return View(_ExpenseCatDetails);
        }


        public IActionResult Delete(int? ExpenseCategotyId)
        {

            var _ExpenseDetails = _context.ExpsenseCategories.Find(ExpenseCategotyId);

            if (_ExpenseDetails == null)
            {
                return NotFound();
            }
            _context.ExpsenseCategories.Remove(_ExpenseDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
