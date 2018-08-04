using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novateca.Web.Models;

namespace Novateca.Web.Controllers
{
    public class AccountController : Controller
    {

        const string SessionUsername = "_Username";
        const string SessionUserID = "_ID";

        private readonly NovatecaDbContext _context;

        public AccountController(NovatecaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var usr = _context.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            if (usr != null)
            {

                HttpContext.Session.SetString(SessionUsername, usr.Username.ToString());
                HttpContext.Session.SetString(SessionUserID, usr.UserID.ToString());
                return RedirectToAction("Loggedin");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong");
            }

            return View();
        }

        public ActionResult loggedIn()
        {
            if (HttpContext.Session.GetString(SessionUserID) == "_ID")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Users");
            }
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
               
                _context.Users.Add(user);
                _context.SaveChanges();
                
                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " cadastro realizado!";
            }
            return RedirectToAction("Index", "Home");
        }
    }

    

}