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
    public class BookCommentsController : Controller
    {
        private readonly NovatecaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookCommentsController(NovatecaDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: BookComments
        public async Task<IActionResult> Index()
        {
            var novatecaDbContext = _context.BookComments.Include(b => b.ApplicationUser).Include(b => b.Book);
            return View(await novatecaDbContext.ToListAsync());
        }

        // GET: BookComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookComment = await _context.BookComments
                .Include(b => b.ApplicationUser)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookCommentID == id);
            if (bookComment == null)
            {
                return NotFound();
            }

            return View(bookComment);
        }

        // GET: BookComments/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
        //    ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition");
        //    return View();
        //}

        // POST: BookComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Comment, [Bind("BookCommentID,UserID,BookID,Comment,CommentDate,CommentEnabled")] BookComment bookComment)
        {
            var userId = int.Parse(_userManager.GetUserId(HttpContext.User));
            bookComment.UserID = userId;
            bookComment.CommentDate = DateTime.Now;
            bookComment.CommentEnabled = true;
            bookComment.Comment = Comment ;
            _context.Add(bookComment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Books", new { id = bookComment.BookID });
           
        }

        public async Task<IActionResult> DisabledComment(int id)
        {
            BookComment bookComment = _context.BookComments.Where(bc => bc.BookCommentID == id).First();
            bookComment.CommentEnabled = false;
            _context.Update(bookComment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details","Books", new { id = bookComment.BookID });
        }

        //// GET: BookComments/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bookComment = await _context.BookComments.FindAsync(id);
        //    if (bookComment == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", bookComment.UserID);
        //    ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookComment.BookID);
        //    return View(bookComment);
        //}

        // POST: BookComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookCommentID,UserID,BookID,Comment,CommentDate,CommentEnabled")] BookComment bookComment)
        {
            if (id != bookComment.BookCommentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCommentExists(bookComment.BookCommentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", bookComment.UserID);
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookComment.BookID);
            return View(bookComment);
        }

        // GET: BookComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookComment = await _context.BookComments
                .Include(b => b.ApplicationUser)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookCommentID == id);
            if (bookComment == null)
            {
                return NotFound();
            }

            return View(bookComment);
        }

        // POST: BookComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookComment = await _context.BookComments.FindAsync(id);
            _context.BookComments.Remove(bookComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCommentExists(int id)
        {
            return _context.BookComments.Any(e => e.BookCommentID == id);
        }
    }
}
