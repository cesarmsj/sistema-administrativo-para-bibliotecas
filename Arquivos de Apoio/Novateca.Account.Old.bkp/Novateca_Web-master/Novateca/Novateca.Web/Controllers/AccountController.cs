using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novateca.Web.Models;

namespace Novateca.Web.Controllers
{
    public class AccountController : Controller
    {

        const string SessionUsername = "_Username";
        const string SessionUserID = "_ID";

        // GET: Account
        public ActionResult Index()
        {
           using(OurDbContext db = new OurDbContext())
            {
                return View(db.userAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using(OurDbContext db = new OurDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered.";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using(OurDbContext db = new OurDbContext())
            {
                var usr = db.userAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if(usr != null)
                {

                    HttpContext.Session.SetString(SessionUsername, usr.Username.ToString());
                    HttpContext.Session.SetString(SessionUserID, usr.UserID.ToString());
                    return RedirectToAction("Loggedin");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }

                
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
                return RedirectToAction("Login");
            }
        }
    }
}