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
    public class ModulesController : Controller
    {
        private readonly UsersDbContext _context;

        public ModulesController(UsersDbContext context)
        {
            _context = context;
        }

        // GET: Modules
        public async Task<IActionResult> Index()
        {
              return _context.Modules != null ? 
                          View(await _context.Modules.ToListAsync()) :
                          Problem("Entity set 'UsersDbContext.Modules'  is null.");
        }

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var modules = await _context.Modules
                .FirstOrDefaultAsync(m => m.id == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // GET: Modules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,courseId,name")] Modules modules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modules);
        }

        // GET: Modules/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var modules = await _context.Modules.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }
            return View(modules);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("id,courseId,name")] Modules modules)
        {
            if (id != modules.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModulesExists(modules.id))
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
            return View(modules);
        }

        // GET: Modules/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var modules = await _context.Modules
                .FirstOrDefaultAsync(m => m.id == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            if (_context.Modules == null)
            {
                return Problem("Entity set 'UsersDbContext.Modules'  is null.");
            }
            var modules = await _context.Modules.FindAsync(id);
            if (modules != null)
            {
                _context.Modules.Remove(modules);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModulesExists(uint id)
        {
          return (_context.Modules?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
