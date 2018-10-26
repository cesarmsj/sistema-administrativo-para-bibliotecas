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
    public class MultimediaLoansController : Controller
    {
        private readonly NovatecaDbContext _context;

        public MultimediaLoansController(NovatecaDbContext context)
        {
            _context = context;
        }

        // GET: MultimediaLoans
        public async Task<IActionResult> Index()
        {
            var novatecaDbContext = _context.MultimediaLoan.Include(m => m.ApplicationUser).Include(m => m.Multimedia);
            return View(await novatecaDbContext.ToListAsync());
        }

        // GET: MultimediaLoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multimediaLoan = await _context.MultimediaLoan
                .Include(m => m.ApplicationUser)
                .Include(m => m.Multimedia)
                .FirstOrDefaultAsync(m => m.MultimediaLoanID == id);
            if (multimediaLoan == null)
            {
                return NotFound();
            }

            return View(multimediaLoan);
        }

        // GET: MultimediaLoans/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "UserName");
            ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "TitleMain");
            return View();
        }

        // POST: MultimediaLoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MultimediaLoanID,LoanDate,DevolutionDate,DevolutionDateMade,UserID,MultimediaID")] MultimediaLoan multimediaLoan)
        {
            if (ModelState.IsValid)
            {

                multimediaLoan.LoanDate = DateTime.Now;
                multimediaLoan.DevolutionDateMade = DateTime.Now.AddDays(7);
                _context.Add(multimediaLoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", multimediaLoan.UserID);
            ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", multimediaLoan.MultimediaID);
            return View(multimediaLoan);
        }

        // GET: MultimediaLoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multimediaLoan = await _context.MultimediaLoan.FindAsync(id);
            if (multimediaLoan == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", multimediaLoan.UserID);
            ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "DGM", multimediaLoan.MultimediaID);
            return View(multimediaLoan);
        }

        // POST: MultimediaLoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MultimediaLoanID,LoanDate,DevolutionDate,DevolutionDateMade,UserID,MultimediaID")] MultimediaLoan multimediaLoan)
        {
            if (id != multimediaLoan.MultimediaLoanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(multimediaLoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultimediaLoanExists(multimediaLoan.MultimediaLoanID))
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
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", multimediaLoan.UserID);
            ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "TitleMain", multimediaLoan.MultimediaID);
            return View(multimediaLoan);
        }

        // GET: MultimediaLoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multimediaLoan = await _context.MultimediaLoan
                .Include(m => m.ApplicationUser)
                .Include(m => m.Multimedia)
                .FirstOrDefaultAsync(m => m.MultimediaLoanID == id);
            if (multimediaLoan == null)
            {
                return NotFound();
            }

            return View(multimediaLoan);
        }

        // POST: MultimediaLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var multimediaLoan = await _context.MultimediaLoan.FindAsync(id);
            _context.MultimediaLoan.Remove(multimediaLoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MultimediaLoanExists(int id)
        {
            return _context.MultimediaLoan.Any(e => e.MultimediaLoanID == id);
        }

        // GET: BookLoans/Create
        public IActionResult Devolution()
        {
            List<String> finalEntries = new List<String>();

            // not sure about your type
            var groupedItemList = (from bl in _context.MultimediaLoan
                                   join b in _context.Multimedia on bl.MultimediaID equals b.MultimediaID
                                   where b.MultimediaID == bl.MultimediaID
                                   select b).ToList();

            ViewData["MultimediaLoans"] = new SelectList(groupedItemList, "MultimediaID", "TitleMain");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Devolution(int id, [Bind("MultimediaLoanID,LoanDate,DevolutionDate,DevolutionDateMade,UserID,MultimediaID")] MultimediaLoan multimediaLoan)
        {
            if (id != multimediaLoan.MultimediaLoanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    multimediaLoan.DevolutionDate = DateTime.Now;
                    _context.Update(multimediaLoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultimediaLoanExists(multimediaLoan.MultimediaLoanID))
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
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", multimediaLoan.UserID);
            ViewData["MultimediaID"] = new SelectList(_context.Multimedia, "MultimediaID", "TitleMain", multimediaLoan.MultimediaID);
            return View(multimediaLoan);
        }
    }
}
