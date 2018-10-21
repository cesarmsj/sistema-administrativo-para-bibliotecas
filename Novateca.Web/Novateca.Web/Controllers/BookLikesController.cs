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
    public class BookLikesController : Controller
    {
        private readonly NovatecaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookLikesController(NovatecaDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: BookLikes
        public async Task<IActionResult> Index()
        {
            var novatecaDbContext = _context.BookLike.Include(b => b.ApplicationUser).Include(b => b.Book);
            return View(await novatecaDbContext.ToListAsync());
        }

        // GET: BookLikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLike = await _context.BookLike
                .Include(b => b.ApplicationUser)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookLikeID == id);
            if (bookLike == null)
            {
                return NotFound();
            }

            return View(bookLike);
        }

        //// GET: BookLikes/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
        //    ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition");
        //    return View();
        //}

        //// POST: BookLikes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("BookLikeID,UserId,BookID,LikeDate,LikeEnabled")] BookLike bookLike)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(bookLike);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", bookLike.UserId);
        //    ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookLike.BookID);
        //    return View(bookLike);
        //}

        //// GET: BookLikes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bookLike = await _context.BookLike.FindAsync(id);
        //    if (bookLike == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", bookLike.UserId);
        //    ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookLike.BookID);
        //    return View(bookLike);
        //}

        // POST: BookLikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("BookLikeID,UserId,BookID,LikeDate,LikeEnabled")] BookLike bookLike)
        //{
        //    if (id != bookLike.BookLikeID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(bookLike);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookLikeExists(bookLike.BookLikeID))
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
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", bookLike.UserId);
        //    ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookLike.BookID);
        //    return View(bookLike);
        //}

        //// GET: BookLikes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bookLike = await _context.BookLike
        //        .Include(b => b.ApplicationUser)
        //        .Include(b => b.Book)
        //        .FirstOrDefaultAsync(m => m.BookLikeID == id);
        //    if (bookLike == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bookLike);
        //}

        //// POST: BookLikes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var bookLike = await _context.BookLike.FindAsync(id);
        //    _context.BookLike.Remove(bookLike);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BookLikeExists(int id)
        //{
        //    return _context.BookLike.Any(e => e.BookLikeID == id);
        //}

        [HttpPost]
        public IActionResult Like(int id)
        {
            try
            {
                var userID = int.Parse(_userManager.GetUserId(HttpContext.User));//Alterar passar id da sessao
                var bookExiste = _context.BookLike.FirstOrDefault(x => x.BookID == id && x.UserId == userID);
                BookLike like = new BookLike();
                if (bookExiste == null)
                {
                    like.BookID = id;
                    like.LikeDate = DateTime.Now;
                    like.UserId = userID;
                    like.LikeEnabled = true;
                    _context.BookLike.Add(like);
                }
                else
                {
                    bookExiste.LikeEnabled = !bookExiste.LikeEnabled;
                    _context.BookLike.Update(bookExiste);
                }
                //var bookLike = await _context.BookLike.FindAsync(id);
                _context.SaveChanges();
                return Json("Salvo com sucesso!");
            }catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
