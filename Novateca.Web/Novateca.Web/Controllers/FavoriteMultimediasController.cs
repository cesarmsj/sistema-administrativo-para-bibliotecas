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
    public class FavoriteMultimediasController : Controller
    {
        private readonly NovatecaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoriteMultimediasController(NovatecaDbContext context, UserManager<ApplicationUser> userManager)
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
                var multimediaExiste = _context.FavoriteMultimedia.FirstOrDefault(x => x.MultimediaID == id && x.UserID == userID);
                FavoriteMultimedia favorite = new FavoriteMultimedia();
                if (multimediaExiste == null)
                {
                    favorite.MultimediaID = id;
                    favorite.FavoriteDate = DateTime.Now;
                    favorite.UserID = userID;
                    favorite.FavoriteEnabled = true;
                    _context.FavoriteMultimedia.Add(favorite);
                }
                else
                {
                    multimediaExiste.FavoriteEnabled = !multimediaExiste.FavoriteEnabled;
                    _context.FavoriteMultimedia.Update(multimediaExiste);
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

        //// GET: FavoriteMultimedias
        //public async Task<IActionResult> Index()
        //{
        //    var novatecaDbContext = _context.FavoriteMultimedia.Include(f => f.ApplicationUser).Include(f => f.Multimedia);
        //    return View(await novatecaDbContext.ToListAsync());
        //}

        //// GET: FavoriteMultimedias/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var favoriteMultimedia = await _context.FavoriteMultimedia
        //        .Include(f => f.ApplicationUser)
        //        .Include(f => f.Multimedia)
        //        .FirstOrDefaultAsync(m => m.FavoriteMultimediaID == id);
        //    if (favoriteMultimedia == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(favoriteMultimedia);
        //}

        //// GET: FavoriteMultimedias/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
        //    ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM");
        //    return View();
        //}

        //// POST: FavoriteMultimedias/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FavoriteMultimediaID,UserID,MultimediaID")] FavoriteMultimedia favoriteMultimedia)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(favoriteMultimedia);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", favoriteMultimedia.UserID);
        //    ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", favoriteMultimedia.MultimediaID);
        //    return View(favoriteMultimedia);
        //}

        //// GET: FavoriteMultimedias/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var favoriteMultimedia = await _context.FavoriteMultimedia.FindAsync(id);
        //    if (favoriteMultimedia == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", favoriteMultimedia.UserID);
        //    ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", favoriteMultimedia.MultimediaID);
        //    return View(favoriteMultimedia);
        //}

        //// POST: FavoriteMultimedias/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("FavoriteMultimediaID,UserID,MultimediaID")] FavoriteMultimedia favoriteMultimedia)
        //{
        //    if (id != favoriteMultimedia.FavoriteMultimediaID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(favoriteMultimedia);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FavoriteMultimediaExists(favoriteMultimedia.FavoriteMultimediaID))
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
        //    ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", favoriteMultimedia.UserID);
        //    ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", favoriteMultimedia.MultimediaID);
        //    return View(favoriteMultimedia);
        //}

        //// GET: FavoriteMultimedias/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var favoriteMultimedia = await _context.FavoriteMultimedia
        //        .Include(f => f.ApplicationUser)
        //        .Include(f => f.Multimedia)
        //        .FirstOrDefaultAsync(m => m.FavoriteMultimediaID == id);
        //    if (favoriteMultimedia == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(favoriteMultimedia);
        //}

        //// POST: FavoriteMultimedias/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var favoriteMultimedia = await _context.FavoriteMultimedia.FindAsync(id);
        //    _context.FavoriteMultimedia.Remove(favoriteMultimedia);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool FavoriteMultimediaExists(int id)
        //{
        //    return _context.FavoriteMultimedia.Any(e => e.FavoriteMultimediaID == id);
        //}
    }
}
