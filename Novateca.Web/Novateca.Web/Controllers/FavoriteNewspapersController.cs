using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Novateca.Web.Models;

namespace Novateca.Web.Controllers
{
    public class FavoriteNewspapersController : Controller
    {
        private readonly NovatecaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoriteNewspapersController(NovatecaDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult Favorite(int id)
        {
            try
            {
                var userID = int.Parse(_userManager.GetUserId(HttpContext.User));//Alterar passar id da sessao
                var newspaperExiste = _context.FavoriteNewspapers.FirstOrDefault(x => x.NewspaperID == id && x.UserID == userID);
                FavoriteNewspaper favorite = new FavoriteNewspaper();
                if (newspaperExiste == null)
                {
                    favorite.NewspaperID = id;
                    favorite.FavoriteDate = DateTime.Now;
                    favorite.UserID = userID;
                    favorite.FavoriteEnabled = true;
                    _context.FavoriteNewspapers.Add(favorite);
                }
                else
                {
                    newspaperExiste.FavoriteEnabled = !newspaperExiste.FavoriteEnabled;
                    _context.FavoriteNewspapers.Update(newspaperExiste);
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

        //// GET: FavoriteNewspapers
        //public async Task<IActionResult> Index()
        //{
        //    var novatecaDbContext = _context.FavoriteNewspapers.Include(f => f.ApplicationUser).Include(f => f.Newspaper);
        //    return View(await novatecaDbContext.ToListAsync());
        //}

        //// GET: FavoriteNewspapers/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var favoriteNewspaper = await _context.FavoriteNewspapers
        //        .Include(f => f.ApplicationUser)
        //        .Include(f => f.Newspaper)
        //        .FirstOrDefaultAsync(m => m.FavoriteNewspaperID == id);
        //    if (favoriteNewspaper == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(favoriteNewspaper);
        //}

        //// GET: FavoriteNewspapers/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
        //    ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity");
        //    return View();
        //}

        //// POST: FavoriteNewspapers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FavoriteNewspaperID,UserID,NewspaperID,FavoriteDate,FavoriteEnabled")] FavoriteNewspaper favoriteNewspaper)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(favoriteNewspaper);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", favoriteNewspaper.UserID);
        //    ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", favoriteNewspaper.NewspaperID);
        //    return View(favoriteNewspaper);
        //}

        //// GET: FavoriteNewspapers/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var favoriteNewspaper = await _context.FavoriteNewspapers.FindAsync(id);
        //    if (favoriteNewspaper == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", favoriteNewspaper.UserID);
        //    ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", favoriteNewspaper.NewspaperID);
        //    return View(favoriteNewspaper);
        //}

        //// POST: FavoriteNewspapers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("FavoriteNewspaperID,UserID,NewspaperID,FavoriteDate,FavoriteEnabled")] FavoriteNewspaper favoriteNewspaper)
        //{
        //    if (id != favoriteNewspaper.FavoriteNewspaperID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(favoriteNewspaper);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FavoriteNewspaperExists(favoriteNewspaper.FavoriteNewspaperID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", favoriteNewspaper.UserID);
        //    ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", favoriteNewspaper.NewspaperID);
        //    return View(favoriteNewspaper);
        //}

        //// GET: FavoriteNewspapers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var favoriteNewspaper = await _context.FavoriteNewspapers
        //        .Include(f => f.ApplicationUser)
        //        .Include(f => f.Newspaper)
        //        .FirstOrDefaultAsync(m => m.FavoriteNewspaperID == id);
        //    if (favoriteNewspaper == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(favoriteNewspaper);
        //}

        //// POST: FavoriteNewspapers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var favoriteNewspaper = await _context.FavoriteNewspapers.FindAsync(id);
        //    _context.FavoriteNewspapers.Remove(favoriteNewspaper);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool FavoriteNewspaperExists(int id)
        //{
        //    return _context.FavoriteNewspapers.Any(e => e.FavoriteNewspaperID == id);
        //}
    }
}
