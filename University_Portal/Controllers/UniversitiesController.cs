using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University_Portal.Data;
using University_Portal.Models;

namespace University_Portal.Controllers
{
    public class UniversitiesController : Controller
    {
        private readonly UsersDbContext _context;

        public UniversitiesController(UsersDbContext context)
        {
            _context = context;
        }

        // GET: Universities
        public async Task<IActionResult> Index()
        {
              return _context.Universities != null ? 
                          View(await _context.Universities.ToListAsync()) :
                          Problem("Entity set 'UsersDbContext.Universities'  is null.");
        }

        // GET: Universities/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null || _context.Universities == null)
            {
                return NotFound();
            }

            var universities = await _context.Universities
                .FirstOrDefaultAsync(m => m.id == id);
            if (universities == null)
            {
                return NotFound();
            }

            return View(universities);
        }

        // GET: Universities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,location")] Universities universities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universities);
        }

        // GET: Universities/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null || _context.Universities == null)
            {
                return NotFound();
            }

            var universities = await _context.Universities.FindAsync(id);
            if (universities == null)
            {
                return NotFound();
            }
            return View(universities);
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("id,name,location")] Universities universities)
        {
            if (id != universities.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversitiesExists(universities.id))
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
            return View(universities);
        }

        // GET: Universities/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null || _context.Universities == null)
            {
                return NotFound();
            }

            var universities = await _context.Universities
                .FirstOrDefaultAsync(m => m.id == id);
            if (universities == null)
            {
                return NotFound();
            }

            return View(universities);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            if (_context.Universities == null)
            {
                return Problem("Entity set 'UsersDbContext.Universities'  is null.");
            }
            var universities = await _context.Universities.FindAsync(id);
            if (universities != null)
            {
                _context.Universities.Remove(universities);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversitiesExists(uint id)
        {
          return (_context.Universities?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
