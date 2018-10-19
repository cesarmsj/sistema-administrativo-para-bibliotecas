using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Novateca.Web.Models;

namespace Novateca.Web.Controllers
{
    public class BookCommentsController : Controller
    {
        private readonly NovatecaDbContext _context;

        public BookCommentsController(NovatecaDbContext context)
        {
            _context = context;
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
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition");
            return View();
        }

        // POST: BookComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookCommentID,UserID,BookID,Comment,CommentDate,CommentEnabled")] BookComment bookComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", bookComment.UserID);
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookComment.BookID);
            return View(bookComment);
        }

        // GET: BookComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookComment = await _context.BookComments.FindAsync(id);
            if (bookComment == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", bookComment.UserID);
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookComment.BookID);
            return View(bookComment);
        }

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
