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
    public class MultimediasController : Controller
    {
        private readonly NovatecaDbContext _context;

        public MultimediasController(NovatecaDbContext context)
        {
            _context = context;
        }

        // GET: Multimedias
        public async Task<IActionResult> Index()
        {
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
        public async Task<IActionResult> Create([Bind("MultimediaID,TitleMain,DGM,SubTitle,Director,PlaceOfPublication,PublishingCompany,YearOfPublication,PhysicalDescription,MultimediaSubject,Abstract,NoteOfParticipants,TargetAudience,Language,URLImage")] Multimedia multimedia)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Edit(int id, [Bind("MultimediaID,TitleMain,DGM,SubTitle,Director,PlaceOfPublication,PublishingCompany,YearOfPublication,PhysicalDescription,MultimediaSubject,Abstract,NoteOfParticipants,TargetAudience,Language,URLImage")] Multimedia multimedia)
        {
            if (id != multimedia.MultimediaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
