using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Novateca.Web.Models;
using PusherServer;

namespace Novateca.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly NovatecaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(NovatecaDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(_userManager.GetUserId(HttpContext.User));
            var bookLikes = _context.BookLike.Where(x => x.UserId == userId && x.LikeEnabled).Select(s => s.BookID).ToList();
            var favoriteBooks = _context.FavoriteBooks.Where(x => x.UserID == userId && x.FavoriteEnabled).Select(s => s.BookID).ToList();
            ViewBag.BookLikes = bookLikes;
            ViewBag.FavoriteBooks = favoriteBooks;
            return View(await _context.Book.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.BookID == id);

            var Comments = _context.BookComments.Where(x => x.BookID == id && x.CommentEnabled == true).Include(x => x.ApplicationUser).
                Select(s => new UsersComments
                    {
                      UserID = s.UserID,
                      BookCommentID = s.BookCommentID,
                      Comment = s.Comment,
                      Firstname = s.ApplicationUser.FirstName,
                      Lastname = s.ApplicationUser.LastName,
                      PhotoUser = s.ApplicationUser.URLProfilePicture,
                      CommentDate = s.CommentDate
                }).ToList();

            var userId = int.Parse(_userManager.GetUserId(HttpContext.User));

            ViewBag.Comments = Comments;
            ViewBag.UserID = userId;

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<IFormFile> AvatarImage, [Bind("BookID,TitleMain,SubTitle,AuthorMain,Authors,Edition,PlaceOfPublication,PublishingCompany,YearOfPublication,TotalPages,BookSubject, Abstract, ISBN, URLImage,URLEbook")] Book book)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in AvatarImage)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            book.AvatarImage = stream.ToArray();
                        }
                    }
                }
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, List<IFormFile> AvatarImage, [Bind("BookID,TitleMain,SubTitle,AuthorMain,Authors,Edition,PlaceOfPublication,PublishingCompany,Year,TotalPages,BookSubject,Abstract,ISBN,URLImage,URLEbook")] Book book)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var item in AvatarImage)
                    {
                        if (item.Length > 0)
                        {
                            using (var stream = new MemoryStream())
                            {
                                await item.CopyToAsync(stream);
                                book.AvatarImage = stream.ToArray();
                            }
                        }
                    }
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookID))
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
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.BookID == id);
        }

       

 
    }
}
