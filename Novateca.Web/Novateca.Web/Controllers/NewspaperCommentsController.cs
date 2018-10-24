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
    public class NewspaperCommentsController : Controller
    {
        private readonly NovatecaDbContext _context;

        public NewspaperCommentsController(NovatecaDbContext context)
        {
            _context = context;
        }

        // GET: NewspaperComments
        public async Task<IActionResult> Index()
        {
            var novatecaDbContext = _context.NewspaperComments.Include(n => n.ApplicationUser).Include(n => n.Newspaper);
            return View(await novatecaDbContext.ToListAsync());
        }

        // GET: NewspaperComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaperComment = await _context.NewspaperComments
                .Include(n => n.ApplicationUser)
                .Include(n => n.Newspaper)
                .FirstOrDefaultAsync(m => m.NewspaperCommentID == id);
            if (newspaperComment == null)
            {
                return NotFound();
            }

            return View(newspaperComment);
        }

        // GET: NewspaperComments/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
            ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity");
            return View();
        }

        // POST: NewspaperComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewspaperCommentID,UserID,NewspaperID,Comment,CommentDate,CommentEnabled")] NewspaperComment newspaperComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newspaperComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", newspaperComment.UserID);
            ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", newspaperComment.NewspaperID);
            return View(newspaperComment);
        }

        // GET: NewspaperComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaperComment = await _context.NewspaperComments.FindAsync(id);
            if (newspaperComment == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", newspaperComment.UserID);
            ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", newspaperComment.NewspaperID);
            return View(newspaperComment);
        }

        // POST: NewspaperComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewspaperCommentID,UserID,NewspaperID,Comment,CommentDate,CommentEnabled")] NewspaperComment newspaperComment)
        {
            if (id != newspaperComment.NewspaperCommentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newspaperComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewspaperCommentExists(newspaperComment.NewspaperCommentID))
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
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", newspaperComment.UserID);
            ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", newspaperComment.NewspaperID);
            return View(newspaperComment);
        }

        // GET: NewspaperComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaperComment = await _context.NewspaperComments
                .Include(n => n.ApplicationUser)
                .Include(n => n.Newspaper)
                .FirstOrDefaultAsync(m => m.NewspaperCommentID == id);
            if (newspaperComment == null)
            {
                return NotFound();
            }

            return View(newspaperComment);
        }

        // POST: NewspaperComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newspaperComment = await _context.NewspaperComments.FindAsync(id);
            _context.NewspaperComments.Remove(newspaperComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewspaperCommentExists(int id)
        {
            return _context.NewspaperComments.Any(e => e.NewspaperCommentID == id);
        }
    }
}
