﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Novateca.Web.Models;

namespace Novateca.Web.Controllers
{
    public class NewspaperLoansController : Controller
    {
        private readonly NovatecaDbContext _context;

        public NewspaperLoansController(NovatecaDbContext context)
        {
            _context = context;
        }

        // GET: NewspaperLoans
        public async Task<IActionResult> Index()
        {
            var novatecaDbContext = _context.NewspaperLoan.Include(n => n.ApplicationUser).Include(n => n.Newspaper);
            return View(await novatecaDbContext.ToListAsync());
        }

        // GET: NewspaperLoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaperLoan = await _context.NewspaperLoan
                .Include(n => n.ApplicationUser)
                .Include(n => n.Newspaper)
                .FirstOrDefaultAsync(m => m.NewspaperLoanID == id);
            if (newspaperLoan == null)
            {
                return NotFound();
            }

            return View(newspaperLoan);
        }

        // GET: NewspaperLoans/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "UserName");
            //ViewData["NewspaperTitleMain"] = new SelectList(_context.Newspapers, "NewspaperID", "TitleMain");
            //ViewData["NewspaperEdition"] = new SelectList(_context.Newspapers, "NewspaperID", "Edition");
            DateTime data = Convert.ToDateTime("0001-01-01 00:00:00.0000000");
            // Livros disponíveis são aqueles que não estão emprestados
            var periodicosDevolvidos = from nl in _context.NewspaperLoan
                                        where
                                        nl.DevolutionDate == data
                                        select nl.NewspaperID;

            //now use them in the contains clause...
            var PeriodicosDisponiveis = from n in _context.Newspapers
                                         where !periodicosDevolvidos.Contains(n.NewspaperID)
                                         select new UserNewspaperLoans()
                                         {
                                             NewspaperID = n.NewspaperID,
                                             NewspaperTitle = n.TitleMain

                                         };
            ViewBag.PeriodicosDisponiveis = PeriodicosDisponiveis;
            return View();
        }

        // POST: NewspaperLoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("NewspaperLoanID,LoanDate,DevolutionDate,DevolutionDateMade,UserID,NewspaperID")] NewspaperLoan newspaperLoan)
        {
            if (ModelState.IsValid)
            {
                newspaperLoan.NewspaperID = id;
                newspaperLoan.LoanDate = DateTime.Now;
                newspaperLoan.DevolutionDateMade = DateTime.Now.AddDays(7);
                _context.Add(newspaperLoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", newspaperLoan.UserID);
            ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", newspaperLoan.NewspaperID);
            return View(newspaperLoan);
        }

        // GET: NewspaperLoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaperLoan = await _context.NewspaperLoan.FindAsync(id);
            if (newspaperLoan == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", newspaperLoan.UserID);
            ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", newspaperLoan.NewspaperID);
            return View(newspaperLoan);
        }

        // POST: NewspaperLoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewspaperLoanID,LoanDate,DevolutionDate,DevolutionDateMade,UserID,NewspaperID")] NewspaperLoan newspaperLoan)
        {
            if (id != newspaperLoan.NewspaperLoanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newspaperLoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewspaperLoanExists(newspaperLoan.NewspaperLoanID))
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
            ViewData["UserID"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName", newspaperLoan.UserID);
            ViewData["NewspaperID"] = new SelectList(_context.Newspapers, "NewspaperID", "CurrentPeriodicity", newspaperLoan.NewspaperID);
            return View(newspaperLoan);
        }

        // GET: NewspaperLoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaperLoan = await _context.NewspaperLoan
                .Include(n => n.ApplicationUser)
                .Include(n => n.Newspaper)
                .FirstOrDefaultAsync(m => m.NewspaperLoanID == id);
            if (newspaperLoan == null)
            {
                return NotFound();
            }

            return View(newspaperLoan);
        }

        // POST: NewspaperLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newspaperLoan = await _context.NewspaperLoan.FindAsync(id);
            _context.NewspaperLoan.Remove(newspaperLoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewspaperLoanExists(int id)
        {
            return _context.NewspaperLoan.Any(e => e.NewspaperLoanID == id);
        }

        // GET: NewspaperLoans/Create
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
            var PeriodicosEmprestados = _context.NewspaperLoan.Where(x => x.DevolutionDate == data).Include(x => x.ApplicationUser).

                Select(s => new UserNewspaperLoans
                {
                    NewspaperLoanID = s.NewspaperLoanID,
                    NewspaperTitle = s.Newspaper.TitleMain,
                    Username = s.ApplicationUser.UserName

                }).ToList();
            ViewBag.PeriodicosEmprestados = PeriodicosEmprestados;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Devolution(int id)
        {
            var newspaperLoan = _context.NewspaperLoan.Find(id);

            if (ModelState.IsValid)
            {
                try
                {
                    newspaperLoan.DevolutionDate = DateTime.Now;
                    _context.Update(newspaperLoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewspaperLoanExists(newspaperLoan.NewspaperLoanID))
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
            ViewData["NewspaperID"] = new SelectList(_context.Book, "NewspaperID", "Edition", newspaperLoan.NewspaperID);
            return View(newspaperLoan);
        }

    }
}
