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
    public class BookIssueController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookIssueController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: BookIssue
        public async Task<IActionResult> Index()
        {
              return View(await _context.BookIssue.ToListAsync());
        }

        // GET: BookIssue/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookIssue == null)
            {
                return NotFound();
            }

            var bookIssue = await _context.BookIssue
                .FirstOrDefaultAsync(m => m.IssueId == id);
            if (bookIssue == null)
            {
                return NotFound();
            }

            return View(bookIssue);
        }

        // GET: BookIssue/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookIssue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IssueId,CardNo,ISBN,DueDate")] BookIssue bookIssue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookIssue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookIssue);
        }

        // GET: BookIssue/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookIssue == null)
            {
                return NotFound();
            }

            var bookIssue = await _context.BookIssue.FindAsync(id);
            if (bookIssue == null)
            {
                return NotFound();
            }
            return View(bookIssue);
        }

        // POST: BookIssue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IssueId,CardNo,ISBN,DueDate")] BookIssue bookIssue)
        {
            if (id != bookIssue.IssueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookIssue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookIssueExists(bookIssue.IssueId))
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
            return View(bookIssue);
        }

        // GET: BookIssue/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookIssue == null)
            {
                return NotFound();
            }

            var bookIssue = await _context.BookIssue
                .FirstOrDefaultAsync(m => m.IssueId == id);
            if (bookIssue == null)
            {
                return NotFound();
            }

            return View(bookIssue);
        }

        // POST: BookIssue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookIssue == null)
            {
                return Problem("Entity set 'LibraryDbContext.BookIssue'  is null.");
            }
            var bookIssue = await _context.BookIssue.FindAsync(id);
            if (bookIssue != null)
            {
                _context.BookIssue.Remove(bookIssue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookIssueExists(int id)
        {
          return _context.BookIssue.Any(e => e.IssueId == id);
        }
    }
}
