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
    public class MultimediaLikesController : Controller
    {
        private readonly NovatecaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MultimediaLikesController(NovatecaDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //// GET: MultimediaLikes
        //public async Task<IActionResult> Index()
        //{
        //    var novatecaDbContext = _context.MultimediaLikes.Include(m => m.ApplicationUser).Include(m => m.Multimedia);
        //    return View(await novatecaDbContext.ToListAsync());
        //}

        //// GET: MultimediaLikes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var multimediaLike = await _context.MultimediaLikes
        //        .Include(m => m.ApplicationUser)
        //        .Include(m => m.Multimedia)
        //        .FirstOrDefaultAsync(m => m.MultimediaLikeID == id);
        //    if (multimediaLike == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(multimediaLike);
        //}

        //// GET: MultimediaLikes/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
        //    ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM");
        //    return View();
        //}

        //// POST: MultimediaLikes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("MultimediaLikeID,UserId,MultimediaID,LikeDate,LikeEnabled")] MultimediaLike multimediaLike)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(multimediaLike);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", multimediaLike.UserId);
        //    ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", multimediaLike.MultimediaID);
        //    return View(multimediaLike);
        //}

        //// GET: MultimediaLikes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var multimediaLike = await _context.MultimediaLikes.FindAsync(id);
        //    if (multimediaLike == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", multimediaLike.UserId);
        //    ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", multimediaLike.MultimediaID);
        //    return View(multimediaLike);
        //}

        //// POST: MultimediaLikes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("MultimediaLikeID,UserId,MultimediaID,LikeDate,LikeEnabled")] MultimediaLike multimediaLike)
        //{
        //    if (id != multimediaLike.MultimediaLikeID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(multimediaLike);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MultimediaLikeExists(multimediaLike.MultimediaLikeID))
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
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", multimediaLike.UserId);
        //    ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", multimediaLike.MultimediaID);
        //    return View(multimediaLike);
        //}

        //// GET: MultimediaLikes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var multimediaLike = await _context.MultimediaLikes
        //        .Include(m => m.ApplicationUser)
        //        .Include(m => m.Multimedia)
        //        .FirstOrDefaultAsync(m => m.MultimediaLikeID == id);
        //    if (multimediaLike == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(multimediaLike);
        //}

        //// POST: MultimediaLikes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var multimediaLike = await _context.MultimediaLikes.FindAsync(id);
        //    _context.MultimediaLikes.Remove(multimediaLike);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool MultimediaLikeExists(int id)
        //{
        //    return _context.MultimediaLikes.Any(e => e.MultimediaLikeID == id);
        //}

        [HttpPost]
        public IActionResult Like(int id)
        {
            try
            {
                var userID = int.Parse(_userManager.GetUserId(HttpContext.User));//Alterar passar id da sessao
                var multimediaExiste = _context.MultimediaLikes.FirstOrDefault(x => x.MultimediaID == id && x.UserId == userID);
                MultimediaLike like = new MultimediaLike();
                if (multimediaExiste == null)
                {
                    like.MultimediaID = id;
                    like.LikeDate = DateTime.Now;
                    like.UserId = userID;
                    like.LikeEnabled = true;
                    _context.MultimediaLikes.Add(like);
                }
                else
                {
                    multimediaExiste.LikeEnabled = !multimediaExiste.LikeEnabled;
                    _context.MultimediaLikes.Update(multimediaExiste);
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
