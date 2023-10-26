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
    public class StudentEventsController : Controller
    {
        private readonly PortalDbContext _context;

        public StudentEventsController(PortalDbContext context)
        {
            _context = context;
        }

        // GET: StudentEvents
        public async Task<IActionResult> Index()
        {
            return _context.StudentEvents != null ?
                        View(await _context.StudentEvents.ToListAsync()) :
                        Problem("Entity set 'PortalDbContext.StudentEvents'  is null.");
        }

        // GET: StudentEvents/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null || _context.StudentEvents == null)
            {
                return NotFound();
            }

            var studentEvents = await _context.StudentEvents
                .FirstOrDefaultAsync(m => m.id == id);
            if (studentEvents == null)
            {
                return NotFound();
            }

            return View(studentEvents);
        }

        // GET: StudentEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,studentId,name,description,dateCreated")] StudentEvents studentEvents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentEvents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentEvents);
        }

        // GET: StudentEvents/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null || _context.StudentEvents == null)
            {
                return NotFound();
            }

            var studentEvents = await _context.StudentEvents.FindAsync(id);
            if (studentEvents == null)
            {
                return NotFound();
            }
            return View(studentEvents);
        }

        // POST: StudentEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("id,studentId,name,description,dateCreated")] StudentEvents studentEvents)
        {
            if (id != studentEvents.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentEvents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentEventsExists(studentEvents.id))
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
            return View(studentEvents);
        }

        // GET: StudentEvents/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null || _context.StudentEvents == null)
            {
                return NotFound();
            }

            var studentEvents = await _context.StudentEvents
                .FirstOrDefaultAsync(m => m.id == id);
            if (studentEvents == null)
            {
                return NotFound();
            }

            return View(studentEvents);
        }

        // POST: StudentEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            if (_context.StudentEvents == null)
            {
                return Problem("Entity set 'PortalDbContext.StudentEvents'  is null.");
            }
            var studentEvents = await _context.StudentEvents.FindAsync(id);
            if (studentEvents != null)
            {
                _context.StudentEvents.Remove(studentEvents);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentEventsExists(uint id)
        {
            return (_context.StudentEvents?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
