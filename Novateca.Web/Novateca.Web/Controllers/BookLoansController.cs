using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Novateca.Web.Models;

namespace Novateca.Web.Controllers
{
    public class BookLoansController : Controller
    {
        private readonly NovatecaDbContext _context;

        public BookLoansController(NovatecaDbContext context)
        {
            _context = context;
        }

        // GET: BookLoans
        public async Task<IActionResult> Index()
        {
            var novatecaDbContext = _context.BookLoan.Include(b => b.Book).Include(u => u.ApplicationUser);
            return View(await novatecaDbContext.ToListAsync());
        }

        // GET: BookLoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.BookLoan
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookLoanID == id);
            if (bookLoan == null)
            {
                return NotFound();
            }

            return View(bookLoan);
        }

        // GET: BookLoans/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Username"] = new SelectList(_context.ApplicationUsers, "Id", "UserName");
            //ViewData["BookTitleMain"] = new SelectList(_context.Book, "BookID", "TitleMain");
            //get the primary key ids...
            DateTime data = Convert.ToDateTime("0001-01-01 00:00:00.0000000");
            // Livros disponíveis são aqueles que não estão emprestados
            var livrosDevolvidos = from bl in _context.BookLoan
                                 where
                                 bl.DevolutionDate == data
                                 select bl.BookID;

            //now use them in the contains clause...
            var LivrosDisponiveis = from b in _context.Book
                                   where !livrosDevolvidos.Contains(b.BookID)
                                   select new UserBookLoans()
                                   {
                                       BookID = b.BookID,
                                       BookTitle = b.TitleMain

                                   };
            ViewBag.LivrosDisponiveis = LivrosDisponiveis;
            return View();
        }

        // POST: BookLoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookLoanID,LoanDate,DevolutionDate,DevolutionDateMade,UserID,BookID")] BookLoan bookLoan)
        {
            if (ModelState.IsValid)
            {
                bookLoan.LoanDate = DateTime.Now;
                bookLoan.DevolutionDateMade = DateTime.Now.AddDays(7);
                _context.Add(bookLoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookLoan.BookID);
            return View(bookLoan);
        }

        // GET: BookLoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.BookLoan.FindAsync(id);
            if (bookLoan == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookLoan.BookID);
            return View(bookLoan);
        }

        // POST: BookLoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookLoanID,LoanDate,DevolutionDate,DevolutionDateMade,UserID,BookID")] BookLoan bookLoan)
        {
            if (id != bookLoan.BookLoanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookLoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookLoanExists(bookLoan.BookLoanID))
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
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookLoan.BookID);
            return View(bookLoan);
        }

        // GET: BookLoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.BookLoan
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookLoanID == id);
            if (bookLoan == null)
            {
                return NotFound();
            }

            return View(bookLoan);
        }

        // POST: BookLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookLoan = await _context.BookLoan.FindAsync(id);
            _context.BookLoan.Remove(bookLoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookLoanExists(int id)
        {
            return _context.BookLoan.Any(e => e.BookLoanID == id);
        }

        // GET: BookLoans/Create
        public IActionResult Devolution()
        {
            //List<String> finalEntries = new List<String>();

            // not sure about your type
            //var groupedItemList = (from bl in _context.BookLoan
            //                                join b in _context.Book on bl.BookID equals b.BookID
            //                                where b.BookID == bl.BookID
            //                       select new { bl.BookLoanID, b.TitleMain}).ToList();

            //ViewData["BookLoans"] = new SelectList(groupedItemList, "BookLoanID", "TitleMain");
            DateTime data = Convert.ToDateTime("0001-01-01 00:00:00.0000000");
            var LivrosEmprestados = _context.BookLoan.Where(x => x.DevolutionDate == data).Include(x => x.ApplicationUser).
          
                Select(s => new UserBookLoans
                {
                    BookLoanID = s.BookLoanID,
                    BookTitle = s.Book.TitleMain,
                    Username = s.ApplicationUser.UserName
                    
                }).ToList();
            ViewBag.LivrosEmprestados = LivrosEmprestados;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Devolution(int id)
        {
            var bookLoan = _context.BookLoan.Find(id);

            if (ModelState.IsValid)
            {
                try
                {
                    bookLoan.DevolutionDate = DateTime.Now;
                    _context.Update(bookLoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookLoanExists(bookLoan.BookLoanID))
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
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "Edition", bookLoan.BookID);
            return View(bookLoan);
        }
    }
}
