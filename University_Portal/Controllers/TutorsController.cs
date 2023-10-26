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
    public class TutorsController : Controller
    {
        private readonly PortalDbContext _context;

        public TutorsController(PortalDbContext context)
        {
            _context = context;
        }

        // GET: Tutors
        public async Task<IActionResult> Index()
        {
            return _context.Tutors != null ?
                        View(await _context.Tutors.ToListAsync()) :
                        Problem("Entity set 'PortalDbContext.Tutors'  is null.");
        }

        // GET: Tutors/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null || _context.Tutors == null)
            {
                return NotFound();
            }

            var tutors = await _context.Tutors
                .FirstOrDefaultAsync(m => m.id == id);
            if (tutors == null)
            {
                return NotFound();
            }

            return View(tutors);
        }

        // GET: Tutors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,uniId,name,password,email,isAdmin")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tutors);
        }

        // GET: Tutors/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null || _context.Tutors == null)
            {
                return NotFound();
            }

            var tutors = await _context.Tutors.FindAsync(id);
            if (tutors == null)
            {
                return NotFound();
            }
            return View(tutors);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("id,uniId,name,password,email,isAdmin")] Tutors tutors)
        {
            if (id != tutors.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorsExists(tutors.id))
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
            return View(tutors);
        }

        // GET: Tutors/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null || _context.Tutors == null)
            {
                return NotFound();
            }

            var tutors = await _context.Tutors
                .FirstOrDefaultAsync(m => m.id == id);
            if (tutors == null)
            {
                return NotFound();
            }

            return View(tutors);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            if (_context.Tutors == null)
            {
                return Problem("Entity set 'PortalDbContext.Tutors'  is null.");
            }
            var tutors = await _context.Tutors.FindAsync(id);
            if (tutors != null)
            {
                _context.Tutors.Remove(tutors);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutorsExists(uint id)
        {
            return (_context.Tutors?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
