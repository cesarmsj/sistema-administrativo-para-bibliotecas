using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Novateca.Web.Models;

namespace Novateca.Web.Controllers
{
    public class FavoriteBooksController : Controller
    {
        private readonly NovatecaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoriteBooksController(NovatecaDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Favorite(int id)
        {
            try
            {
                var userID = int.Parse(_userManager.GetUserId(HttpContext.User));//Alterar passar id da sessao
                var bookExiste = _context.FavoriteBooks.FirstOrDefault(x => x.BookID == id && x.UserID == userID);
                FavoriteBook favorite = new FavoriteBook();
                if (bookExiste == null)
                {
                    favorite.BookID = id;
                    favorite.FavoriteDate = DateTime.Now;
                    favorite.UserID = userID;
                    favorite.FavoriteEnabled = true;
                    _context.FavoriteBooks.Add(favorite);
                }
                else
                {
                    bookExiste.FavoriteEnabled = !bookExiste.FavoriteEnabled;
                    _context.FavoriteBooks.Update(bookExiste);
                }
                //var bookLike = await _context.BookLike.FindAsync(id);
                _context.SaveChanges();
                return Json("Marcado como favorito!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}