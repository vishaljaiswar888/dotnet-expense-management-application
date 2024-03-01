using Microsoft.AspNetCore.Mvc;
using ExpenseManagement2.Models;
using ExpenseManagement2.DataLayer;

namespace ExpenseManagement2.Controllers
{
    public class UserProfileController : Controller
    {
        public readonly DBContextExpMgt _context;

        public UserProfileController(DBContextExpMgt context)
        {
            _context = context;
        }

        // Login Page

        public IActionResult Login(string Email, string Password)
        {
            ViewBag.LoginStatus = " ";

            if (ModelState.IsValid)
            {
                var userCheck = _context.UserProfiles.FirstOrDefault
                    (a => a.Email == Email && a.Password == Password);


                if (userCheck == null)
                {
                    ViewBag.LoginStatus = "Invalid Login or Invalid Credentials";
                }

                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }







        // Register

        public IActionResult Registration(UserProfile userDetails)
        {

            if (ModelState.IsValid)
            {
                _context.UserProfiles.Add(userDetails);
                _context.SaveChanges();
                return RedirectToAction("Login");
                
            }
            return View();
        }






        public IActionResult Index()
        {
            return View();
        }
    }
}
