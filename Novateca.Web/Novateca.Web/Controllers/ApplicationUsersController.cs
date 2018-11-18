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
    public class ApplicationUsersController : Controller
    {
        private readonly NovatecaDbContext _context;

        public ApplicationUsersController(NovatecaDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUsers.ToListAsync());
        }

        public async Task<IActionResult> PhotoPerfil()
        {
            return View();
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            var favoriteBooks = _context.FavoriteBooks.Where(x => x.UserID == id && x.FavoriteEnabled).Include(u => u.Book).Select(s => s.Book.TitleMain).ToList();
            ViewBag.favoriteBooks = favoriteBooks;

            var favoriteMultimedias = _context.FavoriteMultimedia.Where(x => x.UserID == id && x.FavoriteEnabled).Include(u => u.Multimedia).Select(s => s.Multimedia.TitleMain).ToList();
            ViewBag.favoriteMultimedias = favoriteMultimedias;

            var favoriteNewspapers = _context.FavoriteNewspapers.Where(x => x.UserID == id && x.FavoriteEnabled).Include(u => u.Newspaper).Select(s => s.Newspaper.TitleMain).ToList();
            ViewBag.favoriteNewspaper = favoriteNewspapers;

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,User_CPF,URLProfilePicture,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                //applicationUser.URLProfilePicture = "/images/users/sem foto.jpg";
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers.FindAsync(id);
            //var applicationUser = await _context.ApplicationUsers.FirstOrDefaultAsync(e => e.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
           
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,User_CPF,URLProfilePicture,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var obj = _context.ApplicationUsers.FirstOrDefault(x => x.Id == id);
                    obj.FirstName = applicationUser.FirstName;
                    obj.Email = applicationUser.Email;
                    obj.LastName = applicationUser.LastName;
                    obj.User_CPF = applicationUser.User_CPF;
                    obj.URLProfilePicture = applicationUser.URLProfilePicture;
                   // obj.FirstName = applicationUser.FirstName;
                    //applicationUser.NormalizedUserName = applicationUser.UserName.Normalize();
                    //applicationUser.NormalizedEmail = applicationUser.Email.Normalize();
                    _context.Update(obj);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return Json(ex.Message);
                    }
                    else
                    {
                       
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Details", "ApplicationUsers", new { id = id });
            }
            
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationUser = await _context.ApplicationUsers.FindAsync(id);
            _context.ApplicationUsers.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(int id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}
