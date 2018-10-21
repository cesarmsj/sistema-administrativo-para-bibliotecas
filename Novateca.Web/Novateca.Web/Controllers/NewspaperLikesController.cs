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
    public class NewspaperLikesController : Controller
    {
        private readonly NovatecaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public NewspaperLikesController(NovatecaDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //// GET: NewspaperLikes
        //public async Task<IActionResult> Index()
        //{
        //    var novatecaDbContext = _context.NewspaperLikes.Include(n => n.ApplicationUser).Include(n => n.Newspaper);
        //    return View(await novatecaDbContext.ToListAsync());
        //}

        //// GET: NewspaperLikes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var newspaperLike = await _context.NewspaperLikes
        //        .Include(n => n.ApplicationUser)
        //        .Include(n => n.Newspaper)
        //        .FirstOrDefaultAsync(m => m.NewspaperLikeID == id);
        //    if (newspaperLike == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(newspaperLike);
        //}

        //// GET: NewspaperLikes/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
        //    ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity");
        //    return View();
        //}

        //// POST: NewspaperLikes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("NewspaperLikeID,UserId,NewspaperID,LikeDate,LikeEnabled")] NewspaperLike newspaperLike)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(newspaperLike);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", newspaperLike.UserId);
        //    ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", newspaperLike.NewspaperID);
        //    return View(newspaperLike);
        //}

        //// GET: NewspaperLikes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var newspaperLike = await _context.NewspaperLikes.FindAsync(id);
        //    if (newspaperLike == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", newspaperLike.UserId);
        //    ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", newspaperLike.NewspaperID);
        //    return View(newspaperLike);
        //}

        //// POST: NewspaperLikes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("NewspaperLikeID,UserId,NewspaperID,LikeDate,LikeEnabled")] NewspaperLike newspaperLike)
        //{
        //    if (id != newspaperLike.NewspaperLikeID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(newspaperLike);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!NewspaperLikeExists(newspaperLike.NewspaperLikeID))
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
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", newspaperLike.UserId);
        //    ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", newspaperLike.NewspaperID);
        //    return View(newspaperLike);
        //}

        //// GET: NewspaperLikes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var newspaperLike = await _context.NewspaperLikes
        //        .Include(n => n.ApplicationUser)
        //        .Include(n => n.Newspaper)
        //        .FirstOrDefaultAsync(m => m.NewspaperLikeID == id);
        //    if (newspaperLike == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(newspaperLike);
        //}

        //// POST: NewspaperLikes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var newspaperLike = await _context.NewspaperLikes.FindAsync(id);
        //    _context.NewspaperLikes.Remove(newspaperLike);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool NewspaperLikeExists(int id)
        //{
        //    return _context.NewspaperLikes.Any(e => e.NewspaperLikeID == id);
        //}

        [HttpPost]
        public IActionResult Like(int id)
        {
            try
            {
                var userID = int.Parse(_userManager.GetUserId(HttpContext.User));//Alterar passar id da sessao
                var newspaperExiste = _context.NewspaperLikes.FirstOrDefault(x => x.NewspaperID == id && x.UserId == userID);
                NewspaperLike like = new NewspaperLike();
                if (newspaperExiste == null)
                {
                    like.NewspaperID = id;
                    like.LikeDate = DateTime.Now;
                    like.UserId = userID;
                    like.LikeEnabled = true;
                    _context.NewspaperLikes.Add(like);
                }
                else
                {
                    newspaperExiste.LikeEnabled = !newspaperExiste.LikeEnabled;
                    _context.NewspaperLikes.Update(newspaperExiste);
                }
                //var bookLike = await _context.BookLike.FindAsync(id);
                _context.SaveChanges();
                return Json("Salvo com sucesso!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

    }
}
