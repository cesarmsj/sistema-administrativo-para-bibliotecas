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

namespace Novateca.Web.Controllers
{
    public class MultimediasController : Controller
    {
        private readonly NovatecaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MultimediasController(NovatecaDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Multimedias
        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(_userManager.GetUserId(HttpContext.User));
            var multimediaLikes = _context.MultimediaLikes.Where(x => x.UserId == userId && x.LikeEnabled).Select(s => s.MultimediaID).ToList();
            var favoriteMultimedias = _context.FavoriteMultimedia.Where(x => x.UserID == userId && x.FavoriteEnabled).Select(s => s.MultimediaID).ToList();
            ViewBag.MultimediaLikes = multimediaLikes;
            ViewBag.FavoriteMultimedias = favoriteMultimedias;
            return View(await _context.Multimedia.ToListAsync());
        }

        // GET: Multimedias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multimedia = await _context.Multimedia
                .FirstOrDefaultAsync(m => m.MultimediaID == id);

            var Comments = _context.MultimediaComments.Where(x => x.MultimediaID == id && x.CommentEnabled == true).Include(x => x.ApplicationUser).
               Select(s => new UsersComments
               {
                   UserID = s.UserID,
                   MultimediaCommentID = s.MultimediaCommentID,
                   Comment = s.Comment,
                   Firstname = s.ApplicationUser.FirstName,
                   Lastname = s.ApplicationUser.LastName,
                   PhotoUser = s.ApplicationUser.URLProfilePicture,
                   CommentDate = s.CommentDate
               }).ToList();

            var userId = int.Parse(_userManager.GetUserId(HttpContext.User));

            ViewBag.Comments = Comments;
            ViewBag.UserID = userId;

            if (multimedia == null)
            {
                return NotFound();
            }

            return View(multimedia);
        }

        // GET: Multimedias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Multimedias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<IFormFile> AvatarImage, [Bind("MultimediaID,TitleMain,DGM,SubTitle,Director,PlaceOfPublication,PublishingCompany,YearOfPublication,PhysicalDescription,MultimediaSubject,Abstract,NoteOfParticipants,TargetAudience,Language,URLImage")] Multimedia multimedia)
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
                            multimedia.AvatarImage = stream.ToArray();
                        }
                    }
                }
                _context.Add(multimedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(multimedia);
        }


        // GET: Multimedias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multimedia = await _context.Multimedia.FindAsync(id);
            if (multimedia == null)
            {
                return NotFound();
            }
            return View(multimedia);
        }

        // POST: Multimedias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, List<IFormFile> AvatarImage, [Bind("MultimediaID,TitleMain,DGM,SubTitle,Director,PlaceOfPublication,PublishingCompany,YearOfPublication,PhysicalDescription,MultimediaSubject,Abstract,NoteOfParticipants,TargetAudience,Language,URLImage")] Multimedia multimedia)
        {
            if (id != multimedia.MultimediaID)
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
                                multimedia.AvatarImage = stream.ToArray();
                            }
                        }
                    }
                    _context.Update(multimedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultimediaExists(multimedia.MultimediaID))
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
            return View(multimedia);
        }

        // GET: Multimedias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multimedia = await _context.Multimedia
                .FirstOrDefaultAsync(m => m.MultimediaID == id);
            if (multimedia == null)
            {
                return NotFound();
            }

            return View(multimedia);
        }

        // POST: Multimedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var multimedia = await _context.Multimedia.FindAsync(id);
            _context.Multimedia.Remove(multimedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MultimediaExists(int id)
        {
            return _context.Multimedia.Any(e => e.MultimediaID == id);
        }
    }
}
