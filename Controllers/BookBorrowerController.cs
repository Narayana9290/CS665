using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class BookBorrowerController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookBorrowerController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: BookBorrower
        public async Task<IActionResult> Index()
        {
              return View(await _context.BookBorrower.ToListAsync());
        }

        // GET: BookBorrower/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookBorrower == null)
            {
                return NotFound();
            }

            var bookBorrower = await _context.BookBorrower
                .FirstOrDefaultAsync(m => m.CardNo == id);
            if (bookBorrower == null)
            {
                return NotFound();
            }

            return View(bookBorrower);
        }

        // GET: BookBorrower/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookBorrower/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardNo,BName,BEmail,BAddress,BooksIssued")] BookBorrower bookBorrower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookBorrower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookBorrower);
        }

        // GET: BookBorrower/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookBorrower == null)
            {
                return NotFound();
            }

            var bookBorrower = await _context.BookBorrower.FindAsync(id);
            if (bookBorrower == null)
            {
                return NotFound();
            }
            return View(bookBorrower);
        }

        // POST: BookBorrower/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardNo,BName,BEmail,BAddress,BooksIssued")] BookBorrower bookBorrower)
        {
            if (id != bookBorrower.CardNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookBorrower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookBorrowerExists(bookBorrower.CardNo))
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
            return View(bookBorrower);
        }

        // GET: BookBorrower/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookBorrower == null)
            {
                return NotFound();
            }

            var bookBorrower = await _context.BookBorrower
                .FirstOrDefaultAsync(m => m.CardNo == id);
            if (bookBorrower == null)
            {
                return NotFound();
            }

            return View(bookBorrower);
        }

        // POST: BookBorrower/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookBorrower == null)
            {
                return Problem("Entity set 'LibraryDbContext.BookBorrower'  is null.");
            }
            var bookBorrower = await _context.BookBorrower.FindAsync(id);
            if (bookBorrower != null)
            {
                _context.BookBorrower.Remove(bookBorrower);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookBorrowerExists(int id)
        {
          return _context.BookBorrower.Any(e => e.CardNo == id);
        }
    }
}
