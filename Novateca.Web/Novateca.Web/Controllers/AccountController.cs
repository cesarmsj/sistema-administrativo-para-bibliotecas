using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Novateca.Web.Models;
using Novateca.Web.Services;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

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


        //falta fazer confirmação de email
        [HttpPost]
        public ActionResult Login(User user)
        {
            HashPasswords serviceHash = new HashPasswords(SHA512.Create());
            user.Password = serviceHash.CriptografarSenha(user.Password);
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

            return RedirectToAction("Index", "Home");
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
                HashPasswords serviceHash = new HashPasswords(SHA512.Create());
                // ver como fazer sendgrid aqui: http://www.macoratti.net/15/10/mvc_cnfrec1.htm
                if(user.Profile == null)
                {
                    user.Profile = "user";
                }
                user.Password = serviceHash.CriptografarSenha(user.Password);
                user.ConfirmPassword = serviceHash.CriptografarSenha(user.ConfirmPassword);
                user.EmailConfirmed = false;
                _context.Users.Add(user);
               _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " cadastro realizado!";
            }
            else
            {
                ViewBag.MyErrorMessage = "Houve um erro ao tentar realizar o cadastro";
            }
            return RedirectToAction("Index", "Home");
        }
    }

    // de onde tirei o código abaixo: https://www.tutorialspoint.com/asp.net_core/asp.net_core_log_in_and_log_out.htm
    /*
    private SignInManager<User> _signManager;
    private UserManager<User> _userManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signManager)
    {
        _userManager = userManager;
        _signManager = signManager;
    }

    [HttpPost]
    public async Task<IActionResult> Register(User model)
    {
        if (ModelState.IsValid)
        {
            var user = new User { Username = model.Username };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View();
    }

    public class LoginViewModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

    }



    [HttpGet]
    public IActionResult Login(string returnUrl = "")
    {
        var model = new LoginViewModel { ReturnUrl = returnUrl };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signManager.PasswordSignInAsync(model.Username,
               model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        ModelState.AddModelError("", "Invalid login attempt");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }



    /**/




}