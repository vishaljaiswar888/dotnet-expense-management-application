using ExpenseManagement2.DataLayer;
using ExpenseManagement2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseManagement2.Controllers
{
    public class ExpenseController : Controller
    {
        public readonly DBContextExpMgt _context;

        public ExpenseController(DBContextExpMgt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseEntity> expensesList = _context.Expenses.ToList();


            // expense category entity se hum expense category id lenge aur us se value nikalenge
            foreach(var obj in expensesList)
            {
                obj.ExpenseCategory = _context.ExpsenseCategories.FirstOrDefault
                    (u => u.ExpenseCategotyId == obj.ExpenseCategotyId);
            }

            return View(expensesList);
        }


        // Create
        public IActionResult Create(ExpenseEntity expenseDetails)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpsenseCategories.Select(i => new SelectListItem
            {
                Text=i.ExpenseCategotyName,
                Value=i.ExpenseCategotyId.ToString()
            });

            ViewBag.PopulateExpCategory = getExpenseCategoryList;


            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseDetails);
        }


        // Update
        public IActionResult GetExpenseDetailsForUpdate(int? Id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpsenseCategories.Select(i => new SelectListItem
            {
                Text = i.ExpenseCategotyName,
                Value = i.ExpenseCategotyId.ToString()
            });

            ViewBag.PopulateExpCategory = getExpenseCategoryList;


            var _ExpenseDetails = _context.Expenses.Find(Id);

            if(_ExpenseDetails==null)
            {
                return NotFound();
            }
            return View(_ExpenseDetails);
        }        

        
        [HttpPost]
        public IActionResult Update(ExpenseEntity expenseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseDetails);
        }



        // Delete

        public IActionResult GetExpenseDetailsForDelete(int? Id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpsenseCategories.Select(i => new SelectListItem
            {
                Text = i.ExpenseCategotyName,
                Value = i.ExpenseCategotyId.ToString()
            });

            ViewBag.PopulateExpCategory = getExpenseCategoryList;


            var _ExpenseDetails = _context.Expenses.Find(Id);

            if (_ExpenseDetails == null)
            {
                return NotFound();
            }
            return View(_ExpenseDetails);
        }


        public IActionResult Delete(int? ExpenseId)
        {

            var _ExpenseDetails = _context.Expenses.Find(ExpenseId);

            if (_ExpenseDetails == null)
            {
                return NotFound();
            }
            _context.Expenses.Remove(_ExpenseDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
