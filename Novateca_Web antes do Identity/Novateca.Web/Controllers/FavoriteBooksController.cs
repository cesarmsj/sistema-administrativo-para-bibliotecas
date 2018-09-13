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
    public class FavoriteBooksController : Controller
    {
        private readonly NovatecaDbContext _context;

        public FavoriteBooksController(NovatecaDbContext context)
        {
            _context = context;
        }

        // GET: FavoriteBooks
        public async Task<IActionResult> Index()
        {
            var novatecaDbContext = _context.FavoriteBooks.Include(f => f.Book).Include(f => f.User);
            return View(await novatecaDbContext.ToListAsync());
        }

        // GET: FavoriteBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteBook = await _context.FavoriteBooks
                .Include(f => f.Book)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FavoriteBookID == id);
            if (favoriteBook == null)
            {
                return NotFound();
            }

            return View(favoriteBook);
        }

        // GET: FavoriteBooks/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "PublishingCompany");
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName");
            return View();
        }

        // POST: FavoriteBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoriteBookID,UserID,BookID")] FavoriteBook favoriteBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoriteBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "PublishingCompany", favoriteBook.BookID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName", favoriteBook.UserID);
            return View(favoriteBook);
        }

        // GET: FavoriteBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteBook = await _context.FavoriteBooks.FindAsync(id);
            if (favoriteBook == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "PublishingCompany", favoriteBook.BookID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName", favoriteBook.UserID);
            return View(favoriteBook);
        }

        // POST: FavoriteBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoriteBookID,UserID,BookID")] FavoriteBook favoriteBook)
        {
            if (id != favoriteBook.FavoriteBookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteBookExists(favoriteBook.FavoriteBookID))
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
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "PublishingCompany", favoriteBook.BookID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName", favoriteBook.UserID);
            return View(favoriteBook);
        }

        // GET: FavoriteBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteBook = await _context.FavoriteBooks
                .Include(f => f.Book)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FavoriteBookID == id);
            if (favoriteBook == null)
            {
                return NotFound();
            }

            return View(favoriteBook);
        }

        // POST: FavoriteBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteBook = await _context.FavoriteBooks.FindAsync(id);
            _context.FavoriteBooks.Remove(favoriteBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteBookExists(int id)
        {
            return _context.FavoriteBooks.Any(e => e.FavoriteBookID == id);
        }
    }
}
