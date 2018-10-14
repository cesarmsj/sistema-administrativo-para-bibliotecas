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
    public class NewspapersController : Controller
    {
        private readonly NovatecaDbContext _context;

        public NewspapersController(NovatecaDbContext context)
        {
            _context = context;
        }

        // GET: Newspapers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Newspapers.ToListAsync());
        }

        // GET: Newspapers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaper = await _context.Newspapers
                .FirstOrDefaultAsync(m => m.NewspaperID == id);
            if (newspaper == null)
            {
                return NotFound();
            }

            return View(newspaper);
        }

        // GET: Newspapers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Newspapers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewspaperID,TitleMain,SubTitle,Edition,Locate,PublishingCompany,Subject,CurrentPeriodicity,URLImage")] Newspaper newspaper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newspaper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newspaper);
        }

        // GET: Newspapers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaper = await _context.Newspapers.FindAsync(id);
            if (newspaper == null)
            {
                return NotFound();
            }
            return View(newspaper);
        }

        // POST: Newspapers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewspaperID,TitleMain,SubTitle,Edition,Locate,PublishingCompany,Subject,CurrentPeriodicity,URLImage")] Newspaper newspaper)
        {
            if (id != newspaper.NewspaperID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newspaper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewspaperExists(newspaper.NewspaperID))
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
            return View(newspaper);
        }

        // GET: Newspapers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaper = await _context.Newspapers
                .FirstOrDefaultAsync(m => m.NewspaperID == id);
            if (newspaper == null)
            {
                return NotFound();
            }

            return View(newspaper);
        }

        // POST: Newspapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newspaper = await _context.Newspapers.FindAsync(id);
            _context.Newspapers.Remove(newspaper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewspaperExists(int id)
        {
            return _context.Newspapers.Any(e => e.NewspaperID == id);
        }
    }
}
