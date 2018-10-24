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
    public class MultimediaCommentsController : Controller
    {
        private readonly NovatecaDbContext _context;

        public MultimediaCommentsController(NovatecaDbContext context)
        {
            _context = context;
        }

        // GET: MultimediaComments
        public async Task<IActionResult> Index()
        {
            var novatecaDbContext = _context.MultimediaComments.Include(m => m.ApplicationUser).Include(m => m.Multimedia);
            return View(await novatecaDbContext.ToListAsync());
        }

        // GET: MultimediaComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multimediaComment = await _context.MultimediaComments
                .Include(m => m.ApplicationUser)
                .Include(m => m.Multimedia)
                .FirstOrDefaultAsync(m => m.MultimediaCommentID == id);
            if (multimediaComment == null)
            {
                return NotFound();
            }

            return View(multimediaComment);
        }

        // GET: MultimediaComments/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
            ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM");
            return View();
        }

        // POST: MultimediaComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MultimediaCommentID,UserID,MultimediaID,Comment,CommentDate,CommentEnabled")] MultimediaComment multimediaComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(multimediaComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", multimediaComment.UserID);
            ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", multimediaComment.MultimediaID);
            return View(multimediaComment);
        }

        // GET: MultimediaComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multimediaComment = await _context.MultimediaComments.FindAsync(id);
            if (multimediaComment == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", multimediaComment.UserID);
            ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", multimediaComment.MultimediaID);
            return View(multimediaComment);
        }

        // POST: MultimediaComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MultimediaCommentID,UserID,MultimediaID,Comment,CommentDate,CommentEnabled")] MultimediaComment multimediaComment)
        {
            if (id != multimediaComment.MultimediaCommentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(multimediaComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultimediaCommentExists(multimediaComment.MultimediaCommentID))
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
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", multimediaComment.UserID);
            ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", multimediaComment.MultimediaID);
            return View(multimediaComment);
        }

        // GET: MultimediaComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multimediaComment = await _context.MultimediaComments
                .Include(m => m.ApplicationUser)
                .Include(m => m.Multimedia)
                .FirstOrDefaultAsync(m => m.MultimediaCommentID == id);
            if (multimediaComment == null)
            {
                return NotFound();
            }

            return View(multimediaComment);
        }

        // POST: MultimediaComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var multimediaComment = await _context.MultimediaComments.FindAsync(id);
            _context.MultimediaComments.Remove(multimediaComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MultimediaCommentExists(int id)
        {
            return _context.MultimediaComments.Any(e => e.MultimediaCommentID == id);
        }
    }
}
